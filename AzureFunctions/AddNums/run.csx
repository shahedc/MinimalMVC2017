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

    // get params
    string n1 = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "n1", true) == 0)
        .Value;

    string n2 = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "n2", true) == 0)
        .Value;
    
    string n3 = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "n3", true) == 0)
        .Value;
    string n4 = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "n4", true) == 0)
        .Value;
    

    // get operator (add, subtract, multiply, divide)
    string op = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "op", true) == 0)
        .Value;

    // initialize result and get value based on operator.
    int result = 0;
    
    if (op == "add")
        result = Convert.ToInt32(n1) + Convert.ToInt32(n2);
    else if (op == "subtract")
        result = Convert.ToInt32(n1) - Convert.ToInt32(n2);
    else if (op == "multiply")
        result = Convert.ToInt32(n1) * Convert.ToInt32(n2);
    else if (op == "divide")
        result = Convert.ToInt32(n1) / Convert.ToInt32(n2);
    else if (op == "modulus")
        result = Convert.ToInt32(n1) % Convert.ToInt32(n2);
    else if (op == "pattern")
        result = await GetPattern(Convert.ToInt32(n1),Convert.ToInt32(n2),Convert.ToInt32(n3),Convert.ToInt32(n4));

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Set name to query string or body data
    // name = name ?? data?.name;
    n1 = n1 ?? data?.n1;
    n2 = n2 ?? data?.n2;
    n3 = n3 ?? data?.n3;
    n4 = n4 ?? data?.n4;
    op = op ?? data?.op;

    //var resultText = "Result of (" + n1 + " and " + n2 + ") with " + op + " operation = " + result + ".";

    /* 
    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
    */
        return result == null
    ? req.CreateResponse(HttpStatusCode.BadRequest, "Bad request.")
    : req.CreateResponse(HttpStatusCode.OK, result);   
}
 
static async Task<int> GetPattern()
{
    return 88;
}
static async Task<int> GetPattern(int n1,int n2,int n3,int n4)
{
    int next = 0;
    int direction = 0;
    // check sequence direction
    if ((n1 > n2) && (n2 > n3) && (n3 > n4))
    {
        // descending order!
        direction = -1;
    } else if ((n4 > n3) && (n3 > n2) && (n2 > n1))
    {
        // ascending order!
        direction = 1;
    }

    // calculate next 
    next = n4 + direction;

    bool checkEven = IsEven(n1);
    if (IsEven(n1) && IsEven(n2) && IsEven(n3) && IsEven(n4))
    {
        next = n4 + (direction * GetDiff(n4-n3));
    }
    if (IsOdd(n1) && IsOdd(n2) && IsOdd(n3) && IsOdd(n4))
    {
        next = n4 + (direction * GetDiff(n4-n3));
    }
/* 
    // check even
    if (IsEven(n1) && IsEven(n2) && IsEven(n3) && IsEven(n4))
    {
        // even sequence
        next = n4 + (direction * (n4-n3))
    }

    // check odd 
    if (IsOdd(n1) && IsOdd(n2) && IsOdd(n3) && IsOdd(n4))
    {
        // odd sequence
        next = n4 + (direction * (n4-n3))
    }
*/
    return (next);
}
private static int GetDiff(int value)
{
    return ((value > 0) ? (value) : (value * -1));
}
 
private static bool IsOdd(int value)
{
    return value % 2 != 0;
}
private static bool IsEven(int value)
{
    return value % 2 == 0;
}