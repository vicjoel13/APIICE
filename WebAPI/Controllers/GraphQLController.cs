using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;


[Route("graphql")]
public class GraphQLController : Controller
{
    private readonly IDocumentExecuter _documentExecuter;
    private readonly ISchema _schema;

    public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
    {
        _documentExecuter = documentExecuter;
        _schema = schema;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
        if (query == null) { throw new ArgumentNullException(nameof(query)); }

        var executionOptions = new ExecutionOptions
        {
            Schema = _schema,
            Query = query.Query
        };

        var result = await _documentExecuter.ExecuteAsync(executionOptions);

        if (result.Errors?.Count > 0)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
