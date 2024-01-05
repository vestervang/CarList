using DAL.Contexts.Interfaces;
using DAL.Utilities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CurrentListings.Instance.Listings.Add(listing);
        }
    }
}
