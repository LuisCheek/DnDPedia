//----------------------------------------------------------------
// @Description: 
// 
// @Author: Luis Betancourt
// 
// @Date: 27/07/2022
// 
// @Copyright (c) 2022 D&DPedia
//----------------------------------------------------------------

//--Namespaces----------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.Data;

using UnityEngine;
//----------------------------------------------------------------

namespace DnDPedia.DatabaseManager
{
    public class Reader
    {
        public Reader(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        // Database connection object
        private IDbConnection dbConnection;
    }
}
