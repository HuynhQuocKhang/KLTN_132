﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UserBO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Permission { get; set; }
        public string StoreId { get; set; }
        public string UserFullName { get; set; }
    }
}
