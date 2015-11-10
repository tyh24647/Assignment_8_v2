using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.SQS;

namespace Common.AmazonData {
    public class SQSHandeler {
        private BasicAWSCredentials amazonCredentials;
        private AmazonSQSClient sqsClient;
        public string QueueURL = "https://sqs.us-east-1.amazonaws.com/710693859467/assignment-8-message-queue";

        public AmazonSQSClient SQSClient {
            get { return sqsClient; }
        }

        public BasicAWSCredentials AmazonCredentials {
            get { return amazonCredentials; }
        }

        public SQSHandeler(BasicAWSCredentials amazonCredentials, AmazonSQSClient sqsClient) {
            if (amazonCredentials != null && sqsClient != null) {
                this.amazonCredentials = amazonCredentials;
                this.sqsClient = sqsClient;
            }
        }
    }
}
