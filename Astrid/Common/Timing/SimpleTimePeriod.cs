using System;
using System.Collections.Generic;
using System.Text;

namespace Astrid.Common.Timing {
    public class SimpleTimePeriod {


        private String name = "";
        private SimpleTime start;
        private SimpleTime end;
        public SimpleTimePeriod() {
        }
        public SimpleTimePeriod(SimpleTime start, SimpleTime end) {
            if (start.TotalSecond <= end.TotalSecond) {
                this.end = end;
                this.start = start;
            }
            else {
                this.end = start;
                this.start = end;
            }

        }
        public SimpleTimePeriod(SimpleTime start, SimpleTime end, String name) : this(start, end){
            this.name = name;
        }

        public SimpleTime GetOverlap(SimpleTimePeriod anotherTimePeriod) {
            if (this.start.isBefore(anotherTimePeriod.start) && this.end.isBefore(anotherTimePeriod.end) && anotherTimePeriod.start.isBefore(this.end)) {
                return this.end.getBefore(anotherTimePeriod.start);
            }
            if (anotherTimePeriod.start.isBefore(this.start) && anotherTimePeriod.end.isBefore(this.end) && this.start.isBefore(anotherTimePeriod.end)) {
                return anotherTimePeriod.end.getBefore(this.start);
            }
            if (anotherTimePeriod.start.isBefore(this.start) && this.end.isBefore(anotherTimePeriod.end)) {
                return this.end.getBefore(this.start);
            }
            if (this.start.isBefore(anotherTimePeriod.start) && anotherTimePeriod.end.isBefore(this.end)) {
                return anotherTimePeriod.end.getBefore(anotherTimePeriod.start);
            }
            return new SimpleTime(0);
        }


        public SimpleTime Period {
            get {
                return new SimpleTime(end.TotalSecond - start.TotalSecond);
            }
        }
        public String Name {
            get {
                return name;
            }
        }
        public SimpleTime End {
            get {
                return end;
            }
            set {
                end = value;
            }
        }
        public SimpleTime Start {
            get {
                return start;
            }
            set {
                start = value;    
            }
        }

        public override string ToString() {
            return start.ToString() + "-" + end.ToString();
        }
       

        public static SimpleTimePeriod PERIOD_1 = new SimpleTimePeriod(new SimpleTime(7, 0, 0), new SimpleTime(8, 0, 0), "1");
        public static SimpleTimePeriod PERIOD_2 = new SimpleTimePeriod(new SimpleTime(12, 0, 0), new SimpleTime(15, 0, 0), "2");
        public static SimpleTimePeriod PERIOD_3 = new SimpleTimePeriod(new SimpleTime(17, 0, 0), new SimpleTime(20, 0, 0), "3");
        public static SimpleTimePeriod PERIOD_4 = new SimpleTimePeriod(new SimpleTime(23, 0, 0), new SimpleTime(23, 30, 0), "4");

    }
}
