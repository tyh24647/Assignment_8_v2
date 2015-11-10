using System;

namespace Common.PeasantFunctions {
    public class PeasantTaskGenerator {
        private string type, message, data;
        public string Type { get { return type; } }
        public string Message { get { return message; } }
        public string Data { get { return data; } }

        private string[] typeOptions = {
            "Carry", "Build", "Survey"
        };

        private string[] carryOptions = {
            "Wood", "Stone", "Bricks", "Cart", "Water", "Food", "Iron",
                "Axe", "Corpse", "Shovel", "Hammer", "Concrete"
        };

        private string[] buildOptions = {
            "Palace", "Terrace", "Tower", "Statue", "Monument", "Farm",
                "Well", "Wall", "Road", "Armory", "Cathedral", "Arena"
        };

        private string[] surveyOptions = {
            "Keep up the good work!", "The emperor will not be pleased!", "Mediocre at best--you can do better!"
        };

        public PeasantTaskGenerator() {
            type = RandArrStr(typeOptions);
            GenerateJsonData();
        }

        private void GenerateJsonData() {
            if (type == typeOptions[0]) {
                message = RandArrStr(carryOptions);
                data = null;
            } else if (type == typeOptions[1]) {
                message = RandArrStr(buildOptions);
                data = RandIntFromRange(0, 5).ToString();
            } else if (type == typeOptions[2]) {
                message = RandArrStr(surveyOptions);
                data = RandIntFromRange(500, 1000).ToString();
            }
        }

        private string RandArrStr(string[] arr) {
            if (arr != null) {
                return arr[RandIntFromRange(0, arr.Length)];
            }

            return null;
        }

        private int RandIntFromRange(int min, int max) {
            var rand = new Random();
            return rand.Next(min, max);
        }
    }
}
