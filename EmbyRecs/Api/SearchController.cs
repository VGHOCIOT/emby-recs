using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Services;
using System.Linq;
using System.Collections.Generic;

namespace EmbyRecs.Api
{
    [Route("/embyrecs/search", "GET")]
    public class SearchRequest : IReturn<SearchResponse>
    {
        public string Query { get; set; }
    }

    public class SearchResponse
    {
        public List<string> Results { get; set; }
    }

    public class SearchController : IService
    {
        private readonly ILibraryManager _libraryManager;

        public SearchController(ILibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        public object Get(SearchRequest request)
        {
            var queryLower = request.Query.ToLower();

            var items = _libraryManager.RootFolder
                .GetRecursiveChildren()
                .Where(i => i.Name.ToLower().Contains(queryLower))
                .Select(i => i.Name)
                .Take(20) // limit results
                .ToList();

            return new SearchResponse { Results = items };
        }
    }
}