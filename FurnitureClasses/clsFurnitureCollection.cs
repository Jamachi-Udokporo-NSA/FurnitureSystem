﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureClasses
{
    public class clsFurnitureCollection
    {
        // private data member for the list
        List<clsFurniture> mFurnitureList = new List<clsFurniture>();
        // private data member thisFurniture
        clsFurniture mThisFurniture = new clsFurniture();

        // public property for the furniture list
        public List<clsFurniture> FurnitureList
        {
            get
            {
                // return the private data
                return mFurnitureList;
            }
            set
            {
                // set the private data
                mFurnitureList = value;
            }
        }
        public int Count
        {
            get
            {
                // return the count of the list
                return mFurnitureList.Count;
            }
            set
            {
            }
        }
        public clsFurniture ThisFurniture
        {
            get
            {
                // return the private data
                return mThisFurniture;
            }
            set
            {
                // set the private data
                mThisFurniture = value;
            }
        }

        // constructor for the class
        public clsFurnitureCollection()
        {
            // var for the index
            Int32 Index = 0;
            // var to store the record count
            Int32 RecordCount = 0;
            // object for data connection
            clsDataConnection DB = new clsDataConnection();
            // execute the stored procedure
            DB.Execute("sproc_tblFurniture_SelectAll");
            //// get the count of records
            //RecordCount = DB.Count;
            //// while there are records to process
            //while (Index < RecordCount)
            //{
            //    // create a blank furniture
            //    clsFurniture AFurniture = new clsFurniture();
            //    // read in the fields from the current record
            //    AFurniture.FurnitureId = Convert.ToInt32(DB.DataTable.Rows[Index]["FurnitureID"]);
            //    AFurniture.Category = Convert.ToString(DB.DataTable.Rows[Index]["Category"]);
            //    AFurniture.Name = Convert.ToString(DB.DataTable.Rows[Index]["Name"]);
            //    AFurniture.WoodType = Convert.ToString(DB.DataTable.Rows[Index]["WoodType"]);
            //    AFurniture.Colour = Convert.ToString(DB.DataTable.Rows[Index]["Colour"]);
            //    AFurniture.Size = Convert.ToDouble(DB.DataTable.Rows[Index]["Size"]);
            //    AFurniture.StockNo = Convert.ToInt32(DB.DataTable.Rows[Index]["StockNo"]);
            //    AFurniture.Price = Convert.ToDouble(DB.DataTable.Rows[Index]["Price"]);
            //    // add the record to the private data member
            //    mFurnitureList.Add(AFurniture);
            //    // points at the next record
            //    Index++;
            //}
            // populate the array list with the data table
            PopulateArray(DB);
        }

        public int Add()
        {
            // adds a new record to the database based on the values of mThisFurniture
            // connect to the database
            clsDataConnection DB = new clsDataConnection();
            // set the parameters for the stored procedure
            DB.AddParameter("@Category", mThisFurniture.Category);
            DB.AddParameter("@Name", mThisFurniture.Name);
            DB.AddParameter("@WoodType", mThisFurniture.WoodType);
            DB.AddParameter("@Colour", mThisFurniture.Colour);
            DB.AddParameter("@Size", mThisFurniture.Size);
            DB.AddParameter("@StockNo", mThisFurniture.StockNo);
            DB.AddParameter("@Price", mThisFurniture.Price);
            // execute the query returning the primary key value
            return DB.Execute("sproc_tblFurniture_Insert");
        }

        public void Delete()
        {
            // delete the record pointed to by ThisFurniture
            // connect to the database
            clsDataConnection DB = new clsDataConnection();
            // set the parameters for the stored procedure
            DB.AddParameter("@FurnitureId", mThisFurniture.FurnitureId);
            // execute the stored procedure
            DB.Execute("sproc_tblFurniture_Delete");
        }

        public void Update()
        {
            // update an existing record based on the values of ThisFurniture
            // connect to the database
            clsDataConnection DB = new clsDataConnection();
            // set the parameter for the stored procedure
            DB.AddParameter("@FurnitureId", mThisFurniture.FurnitureId);
            DB.AddParameter("@Category", mThisFurniture.Category);
            DB.AddParameter("@Name", mThisFurniture.Name);
            DB.AddParameter("@WoodType", mThisFurniture.WoodType);
            DB.AddParameter("@Colour", mThisFurniture.Colour);
            DB.AddParameter("@Size", mThisFurniture.Size);
            DB.AddParameter("@StockNo", mThisFurniture.StockNo);
            DB.AddParameter("@Price", mThisFurniture.Price);
            //execute the stored procedure
            DB.Execute("sproc_tblFurniture_Update");
        }

        public void ReportByCategory(string Category)
        {
            // filters the records based on a full or partial post code
            // connect to the database
            clsDataConnection DB = new clsDataConnection();
            // send the category parameter to the database
            DB.AddParameter("@Category", Category);
            // execute the stored procedure
            DB.Execute("sproc_tblFurnitureByCategory");
            // populate the array list with the data table
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            // populates the array list based on the data table in the parameter DB
            // var for the index
            Int32 Index = 0;
            // var to store the record count
            Int32 RecordCount;
            // get the count of records
            RecordCount = DB.Count;
            // clear the private array list
            mFurnitureList = new List<clsFurniture>();
            // while there are records to process
            while (Index < RecordCount)
            {
                // create a blank furniture
                clsFurniture AFurniture = new clsFurniture();
                // read in the fields from the current record
                AFurniture.FurnitureId = Convert.ToInt32(DB.DataTable.Rows[Index]["FurnitureID"]);
                AFurniture.Category = Convert.ToString(DB.DataTable.Rows[Index]["Category"]);
                AFurniture.Name = Convert.ToString(DB.DataTable.Rows[Index]["Name"]);
                AFurniture.WoodType = Convert.ToString(DB.DataTable.Rows[Index]["WoodType"]);
                AFurniture.Colour = Convert.ToString(DB.DataTable.Rows[Index]["Colour"]);
                AFurniture.Size = Convert.ToDouble(DB.DataTable.Rows[Index]["Size"]);
                AFurniture.StockNo = Convert.ToInt32(DB.DataTable.Rows[Index]["StockNo"]);
                AFurniture.Price = Convert.ToDouble(DB.DataTable.Rows[Index]["Price"]);
                // add the record to the private data member
                mFurnitureList.Add(AFurniture);
                // point at the next record
                Index++;
            }
        }
    }
}
