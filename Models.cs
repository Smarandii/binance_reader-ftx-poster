using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binance_reader_ftx_poster
{
    class Post_Order_Parameters
    {
        string market = "";
        string side = "";
        double price = 0;
        double size = 0;
        string type = "";
        bool reduceOnly = false;
        bool ioc = false;
        bool postOnly = false;
        string clientId = null;
    }
}
