using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Common.AmazonData;
using Common.PeasantFunctions;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon;

namespace Assignment_8_v2 {
    public class Program {
        private string queueURL, userID, userKey;
        private BasicAWSCredentials amazonCredentials;
        private AmazonSQSClient sqsClient;
        private UserInfoDelegate userData;
        private SQSHandeler sqsHandeler;
        private PeasantTaskGenerator peasantTask;

        // TODO: Get/set these values from namespace Common program.cs file instead
        public void Main(string[] args) {
            InitUserData();
            InitAmazonData();
            InitPeasantTasks();
            queueURL = sqsHandeler.QueueURL;
            amazonCredentials = new BasicAWSCredentials(userID, userKey);
            sqsClient = new AmazonSQSClient(amazonCredentials, RegionEndpoint.USEast1);
            Console.Write("Greetings, overlord!\n\n> How many tasks must"
                + " be given to these lowly peasants? ");
            var userMsg = Console.ReadLine();
            var numPeasantTasks = ParseUserMsg(userMsg);
            
            for (var i = 0; i < numPeasantTasks; i++) {
                var peasantTask = AssignTaskToPeasant();
                peasantTask.Wait();
            }
        }

        private async Task AssignTaskToPeasant() {
            var sendMsgRequest = new SendMessageRequest();
            sendMsgRequest.QueueUrl = queueURL;
            var msgData = RetrievePeasantTask();
            sendMsgRequest.MessageBody = JsonConvert.SerializeObject(msgData);
            await sqsClient.SendMessageAsync(sendMsgRequest);
        }

        private int ParseUserMsg(string userMsg) {
            try {
                return int.Parse(userMsg);
            } catch (Exception) {
                Console.WriteLine("ERROR: Unable to parse the submitted text."
                    + "Please ensure that the entry is in integer format.");
            }

            return -1;
        }

        private JsonMessageData RetrievePeasantTask() {
            return new JsonMessageData() {
                Type = peasantTask.Type,
                Message = peasantTask.Message,
                Data = peasantTask.Data
            };
        }

        private void InitAmazonData() {
            sqsHandeler = new SQSHandeler(amazonCredentials, sqsClient);
            if (sqsHandeler.AmazonCredentials != null
                && sqsHandeler.SQSClient != null) {
                amazonCredentials = sqsHandeler.AmazonCredentials;
                sqsClient = sqsHandeler.SQSClient;
            }
        }

        private void InitUserData() {
            if (userData.UserID != null && userData.UserKey != null) {
                userID = userData.UserID;
                userKey = userData.UserKey;
            }
        }

        private void InitPeasantTasks() {
            if (peasantTask == null) {
                peasantTask = new PeasantTaskGenerator();
            }
        }
    }
}
