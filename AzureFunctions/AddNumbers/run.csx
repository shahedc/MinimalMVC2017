using System;
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    /*
    string name = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        .Value;
    */

    string n1 = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "n1", true) == 0)
        .Value;

    string n2 = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "n2", true) == 0)
        .Value;

    int sum = Convert.ToInt32(n1) + Convert.ToInt32(n2);

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    // name = name ?? data?.name;
    n1 = n1 ?? data?.n1;
    n2 = n2 ?? data?.n2;

    /* 
    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
    */
        return sum == null
    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass in two numbers.")
    : req.CreateResponse(HttpStatusCode.OK, "Sum of (" + n1 + "+" + n2 + ") = " + sum + ".");   
}