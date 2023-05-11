# Step_Academy_AZURE_WebJobs_Image_Min_Lab_5

### Implement a web task that automatically creates a reduced copy of the stored resource of a predetermined size (for example, 200x100 pixels) in the BLOB storage. 
### The web task is activated when a large binary object is added to the images container, smaller copies are placed in the images-min container.
### Use the Azure Application Insights service to log web task life cycle events.
### Deploy a web job to Azure App Service.
### To reduce the size of the image in the ASP.NET Core v3.1 project, you can use the Image class and its methods from the SixLabors.ImageSharp library (installation through the Nuget package). Documentation:
### https://docs.sixlabors.com/api/ImageSharp/SixLabors.ImageSharp.html
