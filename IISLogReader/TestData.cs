using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISLogReader
{
    public static class TestData
    {
        public static string[] LogFileWith404
        {
            get { return _logFileWith404; }
            set { _logFileWith404 = value; }
        }

        public static string[] _logFileWith404 = new string[]
        {
            "#Software: Microsoft Internet Information Services 7.5",
            "#Version: 1.0",
            "#Date: 2014-03-07 00:56:30",
            "#Fields: date time s-ip cs-method cs-uri-stem cs-uri-query s-port cs-username c-ip cs(User-Agent) sc-status sc-substatus sc-win32-status time-taken",
            "2014-03-07 00:56:30 108.161.137.102 GET / - 80 - 202.46.63.47 Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+6.0) 200 0 64 2921",
            "2014-03-07 00:57:13 108.161.137.102 GET / - 80 - 119.63.193.194 Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+6.0) 200 0 64 218",
            "#Software: Microsoft Internet Information Services 7.5",
            "#Version: 1.0",
            "#Date: 2014-03-07 03:06:17",
            "#Fields: date time s-ip cs-method cs-uri-stem cs-uri-query s-port cs-username c-ip cs(User-Agent) sc-status sc-substatus sc-win32-status time-taken",
            "2014-03-07 03:06:17 108.161.137.102 GET / - 80 - 202.46.60.17 Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+6.0) 200 0 64 2953",
            "2014-03-07 03:07:27 108.161.137.102 GET / - 80 - 119.63.193.195 Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+6.0) 200 0 64 187",
            "2014-03-07 03:11:57 108.161.137.102 GET /Home/Services - 80 - 93.186.16.234 Mozilla/5.0+(BlackBerry;+U;+BlackBerry+9700;+en)+AppleWebKit/534.8++(KHTML,+like+Gecko)+Version/6.0.0.448+Mobile+Safari/534.8+ 200 0 0 281",
            "2014-03-07 03:11:58 108.161.137.102 GET /Content/Bootstrap+themes/Boomerang/assets/fraction/fractionslider.css - 80 - 93.186.16.235 Mozilla/5.0+(BlackBerry;+U;+BlackBerry+9700;+en)+AppleWebKit/534.8++(KHTML,+like+Gecko)+Version/6.0.0.448+Mobile+Safari/534.8+ 200 0 0 125",
            "2014-03-07 03:12:00 108.161.137.102 GET /Content/Bootstrap+themes/Boomerang/js/jquery.js - 80 - 93.186.16.237 Mozilla/5.0+(BlackBerry;+U;+BlackBerry+9700;+en)+AppleWebKit/534.8++(KHTML,+like+Gecko)+Version/6.0.0.448+Mobile+Safari/534.8+ 404 0 0 640",
        };

        public static string[] LogFileWith200
        {
            get
            {
                return _logFileWith200;
            }
        }

        public static string[] _logFileWith200 = new string[]
        {
            "#Software: Microsoft Internet Information Services 7.5",
            "#Version: 1.0",
            "#Date: 2014-03-07 00:56:30",
            "#Fields: date time s-ip cs-method cs-uri-stem cs-uri-query s-port cs-username c-ip cs(User-Agent) sc-status sc-substatus sc-win32-status time-taken",
            "2014-03-07 00:56:30 108.161.137.102 GET / - 80 - 202.46.63.47 Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+6.0) 200 0 64 2921",
            "2014-03-07 00:57:13 108.161.137.102 GET / - 80 - 119.63.193.194 Mozilla/4.0+(compatible;+MSIE+7.0;+Windows+NT+6.0) 200 0 64 218",
        };

    }
}
