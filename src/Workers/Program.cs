using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AmazonData;
using Common.PeasantFunctions;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.Runtime;

namespace Workers {
    public class Program {
        private string queueURL, userID, userKey;
        private BasicAWSCredentials amazonCredentials;
        private AmazonSQSClient sqsClient;
        private UserInfoDelegate userData;
        private PeasantTaskGenerator peasantTask;

        public void Main(string[] args) {
            
        }
    }
}
