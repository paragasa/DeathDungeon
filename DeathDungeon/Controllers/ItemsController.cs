using System;
using System.Collections.Generic;
using DeathDungeon.Services;
using DeathDungeon.Models;
using DeathDungeon.ViewModels;
using Newtonsoft.Json.Linq;

namespace DeathDungeon.Controllers
{

    public class ItemsController
    {
        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static ItemsController _instance;

        public static ItemsController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ItemsController();
                }
                return _instance;
            }
        }

        public async void GetItemsFromServer(int parameter = 3)
        {
            // parameter is the item group to request.  1, 2, 3, 100

            // Needs to get items from the server
            // Parse them
            // Then update the database
            // Only update fields on existing items
            // Insert new items
            // Then notify the viewmodel of the change

            // Needs to get items from the server

            var URLComponent = "GetItemList/";

            var DataResult = await HttpClientService.Instance.GetJsonGetAsync(WebGlobals.WebSiteAPIURL + URLComponent + parameter);

            // Parse them
            var myList = ParseJson(DataResult);

            // Then update the database

            // Use a foreach on myList
            foreach (var data in myList)
            {
                await SQLDataStore.Instance.InsertUpdateAsync_Item(data);

            }
            // Call to the new InsertUpdateAsync you made

            // When foreach is done, call to the items view model to set needs refresh to true, so it can refetch the list...
            ItemsViewModel.Instance.SetNeedsRefresh(true);
        }

        // The returned data will be a list of items.  Need to pull that list out
        private List<Item> ParseJson(string myJsonData)
        {
            var myData = new List<Item>();

            try
            {
                JObject json;
                json = JObject.Parse(myJsonData);

                // Data is a List of Items, so need to pull them out one by one...

                var myTempList = json["ItemList"].ToObject<List<JObject>>();

                foreach (var myItem in myTempList)
                {
                    var myTempObject = ConvertFromJson(myItem);
                    if (myTempObject != null)
                    {
                        myData.Add(myTempObject);
                    }
                }

                return myData;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return null;
            }

        }

        private Item ConvertFromJson(JObject json)
        {
            var myData = new Item();

            try
            {
                myData.Name = JsonHelper.GetJsonString(json, "Name");
                myData.Description = JsonHelper.GetJsonString(json, "Description");
                myData.ImageURI = JsonHelper.GetJsonString(json, "ImageURI");
                myData.Guid = JsonHelper.GetJsonString(json, "Guid");
                myData.Id = myData.Guid;   // Set to be the same as Guid, does not come down from server, but needed for DB

                myData.Value = JsonHelper.GetJsonInteger(json, "Value");
                myData.Range = JsonHelper.GetJsonInteger(json, "Range");

                myData.Location = (Location)JsonHelper.GetJsonInteger(json, "Location");
                myData.Attribute = (AttributeEnum)JsonHelper.GetJsonInteger(json, "Attribute");

            }

            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return null;
            }

            return myData;
        }


    }
}
