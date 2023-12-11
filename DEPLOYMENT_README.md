# How to deploy this website to Azure

1. Follow the first three steps of the tutorial [here](https://learn.microsoft.com/en-us/azure/app-service/tutorial-dotnetcore-sqldb-app?pivots=platform-windows).

    a. If there is there is an error pasting in the `StackExchangeRedisCache` code, install the NuGet package
    `Microsoft.Extensions.Caching.StackExchangeRedis` and the error should clear up.

2. In the tutorial step 3.7.3, use this as the code for the workflow step instead of the given code: `dotnet ef migrations bundle --runtime linux-x64 -p FaulknerCountyMuseumGallery.csproj -o ${{env.DOTNET_ROOT}}/myapp/migrate`.

3. Comment out the line `DbInitializer.Initialize(context);` in `Program.cs`.

4. For each of the models in the Models folder, add the data annotation tag `[DatabaseGenerated(DatabaseGeneratedOption.Identity)]` to the ID field (includeing ArtworkID, MediumID, etc.).

5. Delete the Migrations folder to remove any existing SQLite migrations, which would otherwise conflict with the AzureSQL database.

6. Commit and push the current changes.

7. Once the workflow has deployed, do step 4 of the tutorial.

8. If the migration works, uncomment `DbInitializer.Initialize(context);` in `Program.cs`.

9. Commit and push this change.

10. The site should be deployed fully.

If you have any other errors, the website doesn't deploy properly, or the SSH terminal won't open, the App Service Logs can be helpful for debugging. See the tutorial step five for instructions on how to enable and access the App Service Log Stream.