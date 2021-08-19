using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;
/// <summary>
/// Document filter. Adds one new route through /token to be put in the Auth category via POST command.
/// Parameters "application/x-www-form-urlencoded", parameters being permission, user name, and password.
/// </summary>
namespace TRMDataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "Auth"},
                    consumes = new List<string> { "application/x-www-form-urlencoded"},
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"

                        },
                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData",
                            @default = "tim@iamtimcorey.com"
                        },
                        new ParameterClass1.cs
                        {
                            type = "string",
                            name = "password",
                            required = false,
                            @in = "formData",
                            @default = "Pwd12345."
                        }
                    }
                }
            });
        }
    }
}
