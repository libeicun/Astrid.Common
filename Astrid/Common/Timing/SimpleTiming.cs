using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Astrid.Common.Timing
{
    public class SimpleTiming: SimpleTime
    {
        protected static int SECONDS_PER_DAY = 86400;
        protected static int SECONDS_PER_HOUR = 3600;
        protected static int SECONDS_PER_MINUTE = 60;
        protected static int MINUTES_PER_DAY = 1440;
        protected static int MINUTES_PER_HOUR = 60;
        protected static int HOURS_PER_DAY = 24;

        private Timer timer;
        private int day = 0;

        private EventHandler callBack;
        /// <summary>
        /// 指定时间后，调用回调方法。
        /// </summary>
        int dInvoke = 0, hInvoke = 0, mInvoke = 0, sInvoke = 0;


        public SimpleTiming() :base(){
            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(OnTimer);
            timer.Enabled = false;
        }


        public void Pause()
        {
            timer.Enabled = false;
        }
        public void Resume()
        {
            timer.Enabled = true;
        }

        public void ResetTimer()
        {
            timer.Enabled = false;
            timer.Enabled = true;
            totalSecond = 0;
            second = 0;
            minute = 0;
            hour = 0;
            day = 0;
        }
        public override int Second {
            get { return second; }
            set {
                sInvoke = value;
            }
        }
        public override int Minute {
            get {
                return minute;
            }
            set {
                mInvoke = value;
            }
        }
        public override int Hour {
            get {
                return hour;
            }
            set {
                hInvoke = value;
            }
        }
        public int Day {
            get {
                return day;
            }
            set {
                dInvoke = value;
            }
        }
        public String Label {
        get {
                int d = Day;
                int h = Hour;
                int m = Minute;
                int s = Second;
                return (d) + "天 " + (h) + "小时 " + (m) + "分钟 " + (s) + "秒";
            }
        }
        public EventHandler CallBack {
            get {
                return callBack;
            }
            set {
                callBack = value;

            }
        }
       

        void OnTimer(object sender, EventArgs e)
        {
            totalSecond++;

            second++;
            if (second >= SECONDS_PER_MINUTE) {
                second = 0;
                minute++;
                if (minute >= MINUTES_PER_HOUR) {
                    minute = 0;
                    hour++;
                    if (hour >= HOURS_PER_DAY) {
                        hour = 0;
                        day++;
                    }
                }
            }
            if (second == sInvoke &&  minute == mInvoke && hour == hInvoke && day == dInvoke) {
                if (callBack != null) {
                    CallBack(this, null);
                }
            }

        }






    }
}
