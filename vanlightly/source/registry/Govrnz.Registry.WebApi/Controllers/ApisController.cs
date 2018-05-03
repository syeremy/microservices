using System.Collections.Generic;
using System.Threading.Tasks;
using Elcavernas.Govrnz.Registry.WebApi.Model;
using Elcavernas.Govrnz.Registry.WebApi.Model.Apis;
using Microsoft.AspNetCore.Mvc;

namespace Elcavernas.Govrnz.Registry.WebApi.Controllers
{
    /// <summary>
    /// CRUD for API objects
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v1/apis")]
    public class ApisController : Controller
    {
        
        // GET api/v1/apis
        /// <summary>
        /// Returns all API objects
        /// </summary>
        /// <returns>List of all API objects</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApiFull>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetApisAsync()
        {
            return Ok("");
        }
        
        // GET api/v1/apis/{apiName}
        /// <summary>
        /// Get the API object for a given API name.
        /// </summary>
        /// <param name="apiName">The name of the requested API</param>
        /// <returns>API object</returns>
        /// <remarks>If no API matches the name given then a 404 is returned.</remarks>
        [HttpGet("{apiName}")]
        [ProducesResponseType(typeof(ApiFull), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> GetApiAsync(string apiName)
        {
            return Ok("");
        }
        
        // POST api/v1/apis
        /// <summary>
        /// Creates a new API with a 0.1 version in the Inception status
        /// </summary>
        /// <param name="api">The API object</param>
        /// <returns></returns>
        /// <remarks>The SubDomainName property is required and if no sub domain is found that matches the SubDomainName value then a 400 Bad Request is returned.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(void), 201)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> CreateApiAsync([FromBody]ApiCreate api)
        {
            return StatusCode(500);
        }
        
        // PATCH api/v1/apis/
        /// <summary>
        /// Updates the main fields of an API object. You cannot change the sub domain with this action, instead use the move sub resource
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        /// <remarks>
        /// ### REMARKS ###
        /// The following codes are returned
        /// - 400 - No sub domain is found that matches the SubDomainName property
        /// - 200 - Updated an existing API object</remarks>
        [HttpPatch]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> UpdateApiFieldsAsync([FromBody]ApiUpdate api)
        {
            return StatusCode(500);
        }
        
        // POST api/v1/apis/{api-name}/move
        /// <summary>
        /// Creates a new API with a 0.1 version in the Inception status
        /// </summary>
        /// <param name="apiName">The name of the API object</param>
        /// <param name="currentSubDomain">The name of the business sub domain where the API is currently situated</param>
        /// <param name="destinationSubDomain">The name of the business sub domain where the API should be moved to</param>
        /// <returns></returns>
        /// <remarks>The both the old and new sub domains must exist else a 400 Bad Request is returned.</remarks>
        [HttpPost("{apiName}/move")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> MoveApiAsync([FromBody]string apiName, [FromBody]string currentSubDomain, [FromBody]string destinationSubDomain)
        {
            return Ok();
        }

        // DELETE api/v1/apis/{apiName}
        /// <summary>
        /// Deletes an API object.
        /// </summary>
        /// <param name="apiName">Name of API to delete</param>
        /// <returns></returns>
        /// <remarks>No associated Tags are deleted</remarks>
        [HttpDelete("{apiName}")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> DeleteAsync([FromRoute]string apiName)
        {
            return Ok();
        }

        // POST api/v1/apis/{apiName}/versions/
        /// <summary>
        /// Creates a new version of the API
        /// </summary>
        /// <param name="apiName">The name of API object</param>
        /// <param name="version">The new version to be created</param>
        /// <returns></returns>
        /// <remarks>The SubDomainName property is required and if no sub domain is found that matches the SubDomainName value then a 400 Bad Request is returned.</remarks>
        [HttpPost("{apiName}/versions")]
        [ProducesResponseType(typeof(void), 201)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> CreateVersionAsync([FromRoute] string apiName, [FromBody]VersionApi version)
        {
            return StatusCode(500);
        }

        // PUT api/v1/apis/{apiName}/versions/{majorVersion}.{minorVersion}
        /// <summary>
        /// Changes the status of the version of the API
        /// </summary>
        /// <param name="apiName">The name of API object to be updated</param>
        /// <param name="majorVersion">The major version number to be updated </param>
        /// <param name="minorVersion">The minor version number to be updated</param>
        /// <param name="status">The new status of the API version</param>
        /// <returns></returns>
        /// <remarks>The change of API version status is governed by a workflow, if the status change is not valid according to this workflow then a 400 Bad Request is returned</remarks>
        [HttpPut("{apiName}/versions/{majorVersion}.{minorVersion}")]
        [ProducesResponseType(typeof(void), 201)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> UpdateVersionStatusAsync([FromRoute] string apiName, [FromRoute]int majorVersion, [FromRoute]int minorVersion,[FromBody]VersionStatusExternal status)
        {
            return StatusCode(500);
        }

        // DELETE api/v1/apis/{apiName}/versions/{majorVersion}.{minorVersion}
        /// <summary>
        /// Creates a new version of the API
        /// </summary>
        /// <param name="apiName">The name of API object</param>
        /// <param name="majorVersion">The major version number to be updated </param>
        /// <param name="minorVersion">The minor version number to be updated</param>
        /// <returns></returns>
        [HttpDelete("{apiName}/versions/{majorVersion}.{minorVersion}")]
        [ProducesResponseType(typeof(void), 201)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<ActionResult> DeleteVersionAsync([FromRoute] string apiName, [FromRoute]int majorVersion, [FromRoute]int minorVersion)
        {
            return Ok();
        }

        
    }
}