using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MohaliProperty.Dbcontext.Models;
using MohaliProperty.Model;

namespace Mohali_Property_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // get the list of all the companies

        [HttpGet("GetComopanyList")]
        public List<Company_profileVM> GetComopanyList()
        {

            var vm = _context.Company_profileVMs.FromSqlRaw("EXEC manage_company");

            if (vm == null)
            {
                return null;
            }
            else
            {
                return vm.ToList();
            }

        }


        [HttpPost("add_company")]
        public int add_company(Company_profileVM obj) 
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                  new SqlParameter { ParameterName = "@company", Value = obj.company },
                  new SqlParameter { ParameterName = "@company_name", Value = obj.company_name },
                  new SqlParameter { ParameterName = "@email", Value = obj.email },
                  new SqlParameter { ParameterName = "@company_address", Value = obj.company_address },
                  new SqlParameter { ParameterName = "@city", Value = obj.city },
                  new SqlParameter { ParameterName = "@state", Value = obj.state },
                  new SqlParameter { ParameterName = "@pin_code", Value = obj.pin_code },
                  new SqlParameter { ParameterName = "@website", Value = obj.website},
                  new SqlParameter { ParameterName = "@gst_number", Value = obj.gst_number},
                  new SqlParameter { ParameterName = "@status", Value = obj.status},
                  new SqlParameter { ParameterName = "@mobile_number", Value = obj.mobileNumber},
                  new SqlParameter { ParameterName = "@landline_number", Value = obj.landlineNo},
                  new SqlParameter { ParameterName = "@company_logo", Value = obj.company_logo},


            };

            int n = _context.Database.ExecuteSqlRaw("EXEC add_company @company,@company_name,@company_address,@city,@state,@pin_code,@mobile_number,@landline_number,@email,@website,@gst_number,@status,@company_logo", parms.ToArray());

            if(n == 0)
            {
                return 0;
            }
            else
            {
                return 1;

            }

            
        }
        [HttpGet("editcompany")]
        public Company_profileVM editcompany ( int id)
        {
            SqlParameter parm = new SqlParameter("@id", id);
            var company = _context.Company_profileVMs.FromSqlRaw("edits_company @id", parm).ToList().FirstOrDefault();
            if(company == null)
            {
                return null;
            }
            else
            {
                return company;
            }
            
        }

        [HttpPost("update_company")]
        public int update_company (Company_profileVM company)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {

                  new SqlParameter { ParameterName = "@id", Value = company.company_id },
                  new SqlParameter { ParameterName = "@company", Value = company.company },
                  new SqlParameter { ParameterName = "@company_name", Value = company.company_name },
                  new SqlParameter { ParameterName = "@email", Value = company.email },
                  new SqlParameter { ParameterName = "@company_address", Value = company.company_address },
                  new SqlParameter { ParameterName = "@city", Value = company.city },
                  new SqlParameter { ParameterName = "@state", Value = company.state },
                  new SqlParameter { ParameterName = "@pin_code", Value = company.pin_code },
                  new SqlParameter { ParameterName = "@website", Value = company.website},
                  new SqlParameter { ParameterName = "@gst_number", Value = company.gst_number},
                  new SqlParameter { ParameterName = "@status", Value = company.status},
                  new SqlParameter { ParameterName = "@mobile_number", Value = company.mobileNumber},
                  new SqlParameter { ParameterName = "@landline_number", Value = company.landlineNo},
                  new SqlParameter { ParameterName = "@company_logo", Value = company.company_logo},


            };
            var result = _context.Database.ExecuteSqlRaw("update_company @id,@company,@company_name,@company_address,@city,@state,@pin_code,@mobile_number,@landline_number,@email,@website,@gst_number,@status,@company_logo", parms.ToArray());
        
            if(result == 0)
            {
                return result;
            }
            else
            {
                return 1;
            }
        
        }


        [HttpGet("Deletecompany")]
        public int Deletecompany(int id)
        {
            SqlParameter parm = new SqlParameter("@id", id);
            var company = _context.Database.ExecuteSqlRaw("delete_company @id", parm);
            if (company == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }

        [HttpPost("AddKothi")]

        public int add_kothi(KothiModel addkothi)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                   new SqlParameter {ParameterName="@kothi_number",Value=addkothi.kothi_Number},
                   new SqlParameter{ParameterName="@block",Value=addkothi.block},
                   new SqlParameter{ParameterName="@kothi_size" ,Value=addkothi.kothi_size},
                   new SqlParameter{ParameterName="@kothi_description",Value= addkothi.kothi_description},
                   new SqlParameter {ParameterName="@dimension" ,Value=addkothi.dimension},
                   new SqlParameter{ParameterName="@plot_area",Value= addkothi.plot_area},
                   new SqlParameter{ParameterName="@price",Value=addkothi.price},
                   new SqlParameter{ParameterName="@bhk",Value= addkothi.bhk},
                   new SqlParameter{ParameterName="@booking_amount",Value=addkothi.booking_amount},
                   new SqlParameter{ParameterName="@status",Value=addkothi.status},
                   new SqlParameter{ParameterName="@hold",Value= addkothi.hold},
                   new SqlParameter{ParameterName="@kothi_image",Value=addkothi.kothi_image},
                


                };
            var result = _context.Database.ExecuteSqlRaw("add_kothi @kothi_number,@block,@kothi_size,@kothi_description,@dimension,@plot_area,@price,@bhk,@booking_amount,@status,@hold,@kothi_image", parameters.ToArray());


            if (result == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }



        }

        [HttpGet("GetKothiList")]
        public List<KothiModel>GetKothi()
        {
            var vm = _context.kothis.FromSqlRaw("manage_kothies");

            if(vm==null)
            {
                return null;
            }
            else
            {
                return vm.ToList();
            }
        }

       

        [HttpGet("DeleteKothi")]
        public int DeleteKothi(int id)
        {
            SqlParameter parm = new SqlParameter("@id", id);
            var company = _context.Database.ExecuteSqlRaw("delete_kothi @id", parm);
            if(company==0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


        [HttpPost("updateKothi")]
        public int updateKothi(KothiModel addkothi)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName="@id",Value=addkothi.kothi_id},
               new SqlParameter {ParameterName="@kothi_number",Value=addkothi.kothi_Number},
                new SqlParameter {ParameterName="@dimension" ,Value=addkothi.dimension},

              //  new SqlParameter{ParameterName="@kothi_unit",Value=addkothi.kothi_unit},
                new SqlParameter{ParameterName="@block",Value=addkothi.block},
                new SqlParameter{ParameterName="@kothi_size" ,Value=addkothi.kothi_size},
              //  new SqlParameter{ParameterName="@unit_rate" ,Value=addkothi.unit_rate},
                new SqlParameter{ParameterName="@price",Value=addkothi.price},
                new SqlParameter{ParameterName="@booking_amount",Value=addkothi.booking_amount},
                new SqlParameter{ParameterName="@status",Value=addkothi.status},
             //   new SqlParameter{ParameterName="@token_amount" ,Value=addkothi.token_amount}



            };
            var result = _context.Database.ExecuteSqlRaw("updateKothi @id, @kothi_number,@dimension,@block,@kothi_size,@price,@booking_amount,@status", parameters.ToArray());

            if (result == 0)
            {
                return result;
            }
            else
            {
                return 1;
            }

        }


        [HttpGet("editKothi")]
        public KothiModel editKothi(int id)
        {
            SqlParameter parm=new SqlParameter("@id", id);
            var company = _context.kothis.FromSqlRaw("edit_kothi @id", parm).ToList().FirstOrDefault();

            if (company == null)
            {
                return null;
            }
            else
            {
                return company;
            }
        }



    } 
}
