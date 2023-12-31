# MovieCatalog
MovieCatalog-.NetCore-MongoDB

**Highlights of the Project**
  1. Added middleware to track request processing time and save each requests made for movie search.
   ![Untitled](https://github.com/HqRhn/MovieCatalog/assets/141786593/840b7882-9f9f-47ad-8b34-aa6cd7bbb849)
  2. Set up API-Key authentication on Admin actions.
     ![Capture](https://github.com/HqRhn/MovieCatalog/assets/141786593/81fa1a45-3c75-4814-a77d-62d4de469c01)

  3. Additional movies search on 'search token' added.

**Below End-points are present:**

o Movie Search (open, not secured)

-    HTTP-GET where you can supply a movie title

  
o Admin Actions (secure, via API-Key)

-  HTTP-GET to get all stored request entries
-  HTTP-GET to get a single request entry
-  HTTP-GET to search on date period
-  HTTP-GET to report usage on per day (DD-MM-YYYY)
-  Give an overview on the number of requests based on an timestamp 
-  HTTP-DELETE to delete an request entry



**Solution path :** MovieCatalog/MovieCatalog.sln
