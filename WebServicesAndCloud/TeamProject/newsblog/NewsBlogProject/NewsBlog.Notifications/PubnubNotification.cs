using PubNubMessaging.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog.Notifications
{
    public static class PubnubNotification
    {
        private const string SubscribeKey = "sub-c-5c52dc30-0582-11e3-991c-02ee2ddab7fe";
        private const string PublishKey = "pub-c-e52a8135-dc8f-47c9-a195-1d35de03382c";
        private const string SecretKey = "sec-c-ZmQ1YWEzMGYtNjYzYi00ZGU4LTk5MGItMTk4NjhmNTkzNTU0";
        private const string Channel = "newsblog-channel";

        private static readonly Pubnub pubnub = new Pubnub(PublishKey, SubscribeKey);

        public static void SendNotification(string message)
        {
            PubnubAPI pubnub = new PubnubAPI(
            PublishKey,               // PUBLISH_KEY
            SubscribeKey,               // SUBSCRIBE_KEY
            SecretKey,   // SECRET_KEY
            true                                                        // SSL_ON?
        );
            pubnub.Publish(Channel, message);
        }

        private static void Result(Notification notification)
        {

        }
    }
}
