using Domain.Models;

namespace BLL.Services
{
    public interface IListingService
    {
        Listing CreateListing(string name);
        Listing? GetListing(Guid listingId);
        List<Listing> GetListings();
        Listing ImportListingFromFile(string filename, string nameAfterImport);
        void SaveListingToFile(Guid listingId);
    }
}