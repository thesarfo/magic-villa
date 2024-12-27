This is a reference implementation of a .NET Core application demoing things like authentication, caching, pagination, searching, file uploads, etc.

### What was done

- **Authentication and Authorization**
    - JSON Web Tokens (JWT) for secure API authentication.
    - Refresh tokens for session continuity.

- **Caching**
    - Response caching to improve API performance(in memory)

- **Pagination, Filtering, and Searching**
    - API query capabilities.
    - Fetching and filtering data.

- **Micro Frontend with Razor Pages**
    - Implementing a micro frontend architecture using Razor Pages.

- **File Uploading**
    - Upload files directly to filesystem(can be extended to an object storage like Azure Blob Storage.)

### To run this

1. Install dependencies:
   ```bash
   dotnet restore
   ```

2. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
