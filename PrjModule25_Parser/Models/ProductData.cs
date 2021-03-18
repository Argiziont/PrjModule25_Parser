﻿using System;

namespace PrjModule25_Parser.Models
{
    public class ProductData
    {
        //Ids
        public int Id { get; set; }
        public int? ShopId { get; set; }
        public string ExternalId { get; set; }


        //Internal data
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime SyncDate { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        //Json-serialized data
        public string JsonData { get; set; }
        public string JsonDataSchema { get; set; }

        //Data base connections
        public ShopData Shop { get; set; }
    }
}
