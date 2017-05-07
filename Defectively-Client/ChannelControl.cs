using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Defectively;

namespace DefectivelyClient
{
    public partial class ChannelControl : UserControl
    {
        public delegate void LinkClickedEventHandler(object sender, LinkEventArgs e);

        public event LinkClickedEventHandler LinkClicked;

        public virtual void OnLinkClicked(LinkEventArgs e) {
            LinkClicked?.Invoke(this, e);
        }

        public string Id { get; set; }

        private Queue<MessagePacket> MessageQueue = new Queue<MessagePacket>();

        public ChannelControl() {
            InitializeComponent();

            webConversation.Navigating += OnWebConversationNavigating;
            webConversation.DocumentCompleted += OnWebConversationDocumentCompleted;
        }

        private void OnWebConversationDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (MessageQueue.Count > 0) {
                AddMessage(MessageQueue.Dequeue());
            }
        }

        public void Clear() {
            webConversation.DocumentText = "";
            webConversation.Navigate("about:blank");
            webConversation.Navigate(Path.Combine(Application.StartupPath, "style.html"));
        }

        public void AddMessage(MessagePacket message) {
            if (webConversation.ReadyState != WebBrowserReadyState.Complete) {
                MessageQueue.Enqueue(message);
                return;
            }

            switch (message.Type) {
            case Enumerations.MessageType.Center:
                webConversation.DocumentText += $"<div class=\"center\" style=\"background-color: {message.RankColor};\"><p><span class=\"aleft\">{message.Time}</span>{message.Content}</p></div>";
                break;
            case Enumerations.MessageType.Left:
                webConversation.DocumentText += $"<div class=\"left\" style=\"background-color: {message.RankColor};\"><div class=\"top\"><p>{message.SenderPrefix}<span class=\"aright\">@{message.SenderId}</span></p></div><div class=\"content\"><p>{message.Content}</p></div><p class=\"time\">{message.Time}</p><br style = \"clear: both;\" /></div><div class=\"arrow-left\" style=\"border-color: {message.RankColor} transparent transparent;\"></div>";
                break;
            case Enumerations.MessageType.Right:
                webConversation.DocumentText += $"<div class=\"right\" style=\"background-color: {message.RankColor};\"><div class=\"top\"><p>{message.SenderPrefix}<span class=\"aright\">@{message.SenderId}</span></p></div><div class=\"content\"><p>{message.Content}</p></div><p class=\"time\">{message.Time}</p><br style=\"clear: both;\" /></div><br style=\"clear: both;\" /><div class=\"arrow-right\" style=\"border-color: transparent {message.RankColor} transparent transparent;\"></div><br class=\"cb\" />";
                break;
            case Enumerations.MessageType.Broadcast:
                webConversation.DocumentText += $"<div class=\"bcast\" style=\"background-color: {message.RankColor};\"><div class=\"top\"><p style=\"font-size: 12pt; font-weight: 700; text-transform: uppercase;\">{message.SenderPrefix}</p></div><p style=\"padding: 5px 10px;\"><span class=\"aleft\">{message.Time}</span>{message.Content}</p></div>";
                break;
            }

            Application.DoEvents();
            webConversation.Document.Window.ScrollTo(0, webConversation.Document.Body.ScrollRectangle.Height);
        }

        private void OnWebConversationNavigating(object sender, WebBrowserNavigatingEventArgs e) {
            if (e.Url.ToString().Split('/').Last() != "style.html" && e.Url.ToString() != "about:blank") {
                e.Cancel = true;
                OnLinkClicked(new LinkEventArgs(e.Url.ToString()));
            }
        }
    }

    public class LinkEventArgs : EventArgs
    {
        public string Url { get; }

        public LinkEventArgs(string url) {
            Url = url;
        }
    }
}