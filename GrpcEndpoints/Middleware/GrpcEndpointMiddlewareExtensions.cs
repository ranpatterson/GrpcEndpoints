using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcEndpoints
{
    public static class GrpcEndpointMiddlewareExtensions
    {

        public static IApplicationBuilder UseGrpcEndpoint(this IApplicationBuilder builder
            , string protoDirectory = "Protos"
            , string requestPath = "/proto"
            , bool enableDirectoryBrowser = false )
        {
            var env = (IWebHostEnvironment)builder.ApplicationServices.GetService(typeof(IWebHostEnvironment));

            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings.Clear();
            provider.Mappings[".proto"] = "text/plain";

            builder.UseStaticFiles(new StaticFileOptions
            {
                //only serve .proto files
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, protoDirectory)),
                RequestPath = requestPath,
                ContentTypeProvider = provider
            });

            if (enableDirectoryBrowser)
            {
                builder.UseDirectoryBrowser(new DirectoryBrowserOptions
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, protoDirectory)),
                    RequestPath = requestPath
                });
            }


            return builder;
        }
    }
}
