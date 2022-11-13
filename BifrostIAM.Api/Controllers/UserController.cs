using BifrostIAM.Api.Models;
using BifrostIAM.Application.Interfaces;
using BifrostIAM.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BifrostIAM.Api.Controllers
{
    public class UserController : BaseApiController
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ===[ Constructor ]=================================================================

        /// <summary>
        /// Initialize ContactController by injecting an object type of IUnitOfWork
        /// </summary>
        public UserController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        [HttpGet]
        public async Task<ApiResponse<List<User>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<User>>();

            try
            {
                var data = await _unitOfWork.Users.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        #endregion
    }
}
