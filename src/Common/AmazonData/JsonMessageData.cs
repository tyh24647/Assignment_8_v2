using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.AmazonData {
    public class JsonMessageData {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }


        public override string ToString() {
            if (Type != null && Message != null && Data != null) {
                return Type + " " + Message + " " + Data;
            }

            return base.ToString();
        }
    }
}
