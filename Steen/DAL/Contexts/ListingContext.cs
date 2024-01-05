using DAL.Contexts.Interfaces;
using DAL.Utilities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection;

namespace DAL.Contexts
{
    public class ListingContext : IListingContext
    {
        private readonly CarListContext _carListContext;

        public ListingContext(CarListContext carListContext) 
        { 
            _carListContext = carListContext;
        }

        public List<Listing> GetListings()
        {
            return CurrentListings.Instance.Listings;
        }

        public Listing? GetListing(Guid listingId)
        {
            return CurrentListings.Instance.Listings.FirstOrDefault(list => list.Id == listingId);
        }

        public void AddListing(Listing listing)
        {
            //todo: Håndter flere med samme navn
            CurrentListings.Instance.Listings.Add(listing);
        }

        public void SaveListingToFile(Guid listingId)
        {
            var listing = GetListing(listingId);

            if (listing == null)
            {
                throw new Exception("Listing not found, could not save");//todo: vælg exception type
            }

            var json = JsonSerializer.Serialize(listing);
            File.WriteAllText($@"C:\Git\CarList\Steen\App_Data\{listing.Name}.json", json);
        }

        public Listing ImportListingFromFile(string filename, string nameAfterImport)
        {
            Listing? listing;
            using (StreamReader r = new StreamReader($@"C:\Git\CarList\Steen\App_Data\{filename}.json"))
            {
                string json = r.ReadToEnd();

                if (json == null)
                {
                    throw new Exception("File not found, could not import");//todo: vælg exception type
                }

                listing = JsonSerializer.Deserialize<Listing>(json);
            }

            if (listing == null)
            {
                throw new Exception("Could not deserialze file, file not saved");//todo: vælg exception type
            }

            var newListing = new Listing(listing.Cars, nameAfterImport, Guid.NewGuid());

            AddListing(newListing);

            return listing;
        }
    }
}
