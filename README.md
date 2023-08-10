# MovieCatalog
MovieCatalog-.NetCore-MongoDB

**Highlights of the Assignment : **
  1. Added middleware to track request processing time and save each requests made for movie search.
  2. Set up API-Key authentication on Admin actions.
  3. Additional movies search on 'search token' added.

**Below End-points are present:**

o. Movie Search (open, not secured)
  ▪ HTTP-GET where you can supply a movie title
  
o Admin Actions (secure, via API-Key)
▪ HTTP-GET to get all stored request entries
▪ HTTP-GET to get a single request entry
▪ HTTP-GET to search on date period
▪ HTTP-GET to report usage on per day (DD-MM-YYYY)
• Give an overview on the number of requests based on an timestamp 
▪ HTTP-DELETE to delete an request entry


Time estimated : 8 hours 
Actual time taken : Approx 10 hours - took some additional time to finalzie the approach to record request processing time.

**Solution path :** MovieCatalog/MovieCatalog.sln
