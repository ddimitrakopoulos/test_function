using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

public class HelloHttp
{
    [Function("Hello")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
        HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/html; charset=utf-8");

        response.WriteString("""
            <!DOCTYPE html>
            <html lang="en">
            <head>
              <meta charset="UTF-8" />
              <meta name="viewport" content="width=device-width, initial-scale=1.0" />
              <title>Hello from Azure Functions</title>
              <style>
                * { box-sizing: border-box; margin: 0; padding: 0; }
                body {
                  font-family: 'Segoe UI', Tahoma, sans-serif;
                  background: linear-gradient(135deg, #0078d4 0%, #005a9e 100%);
                  min-height: 100vh;
                  display: flex;
                  align-items: center;
                  justify-content: center;
                }
                .card {
                  background: #fff;
                  border-radius: 16px;
                  padding: 56px 72px;
                  box-shadow: 0 8px 40px rgba(0,0,0,0.18);
                  text-align: center;
                  max-width: 480px;
                  width: 90%;
                }
                h1 {
                  font-size: 3.2rem;
                  color: #0078d4;
                  margin-bottom: 12px;
                  letter-spacing: -1px;
                }
                p {
                  font-size: 1.15rem;
                  color: #555;
                  margin-bottom: 28px;
                }
                .badge {
                  display: inline-block;
                  background: #e8f3fc;
                  color: #0078d4;
                  border-radius: 999px;
                  padding: 6px 18px;
                  font-size: 0.9rem;
                  font-weight: 600;
                  letter-spacing: 0.03em;
                }
              </style>
            </head>
            <body>
              <div class="card">
                <h1>Hello, World!</h1>
                <p>Your Azure Function is up and running.</p>
                <span class="badge">.NET 8 &nbsp;·&nbsp; Isolated Worker</span>
              </div>
            </body>
            </html>
            """);

        return response;
    }
}
