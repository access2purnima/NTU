using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TrekStarFilmManagementSystem
{
    internal class MaterialDatabaseActivitySQL : IMaterialDatabaseActivity
    {
        public List<MaterialModel> lstMaterialsModel = new List<MaterialModel>();

        public string sqlConnectionText = ConfigurationSettings.AppSettings.Get("SqlConnection");

        public string Add(MaterialModel MaterialInfo)
        {
            string outputMessage = "";
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(sqlConnectionText))
                {
                    SqlDataAdapter da = new SqlDataAdapter();

                    string sqlCmdText = "INSERT INTO dbo.MaterialInfo (Title,ProjectTitle,MaterialType,Format,AudioFormat,Runtime,ReleaseDate,Language,RetailPrice,SubTitles,FrameAspect,Packaging,AddedDate,AddedBy)"
                                        + "VALUES(@Title,@ProjectTitle,@MaterialType,@Format,@AudioFormat,@Runtime,@ReleaseDate,@Language,@RetailPrice,@SubTitles,@FrameAspect,@Packaging,@AddedDate,@AddedBy)";

                    da.InsertCommand = new SqlCommand(sqlCmdText, sqlCon);
                    da.InsertCommand.Parameters.Add("@Title", SqlDbType.VarChar).Value = MaterialInfo.title;
                    da.InsertCommand.Parameters.Add("@ProjectTitle", SqlDbType.VarChar).Value = MaterialInfo.projectTitle;
                    da.InsertCommand.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = MaterialInfo.materialType;
                    da.InsertCommand.Parameters.Add("@Format", SqlDbType.VarChar).Value = MaterialInfo.format;
                    da.InsertCommand.Parameters.Add("@AudioFormat", SqlDbType.VarChar).Value = MaterialInfo.audioFormat;
                    da.InsertCommand.Parameters.Add("@Runtime", SqlDbType.Time).Value = MaterialInfo.runTime;
                    da.InsertCommand.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = MaterialInfo.releaseDate;
                    da.InsertCommand.Parameters.Add("@Language", SqlDbType.VarChar).Value = MaterialInfo.launguage;
                    da.InsertCommand.Parameters.Add("@RetailPrice", SqlDbType.Money).Value = MaterialInfo.retailPrice;
                    da.InsertCommand.Parameters.Add("@SubTitles", SqlDbType.VarChar).Value = MaterialInfo.subTitles;
                    da.InsertCommand.Parameters.Add("@FrameAspect", SqlDbType.VarChar).Value = MaterialInfo.frameAspect;
                    da.InsertCommand.Parameters.Add("@Packaging", SqlDbType.VarChar).Value = MaterialInfo.packaging;
                    da.InsertCommand.Parameters.Add("@AddedDate", SqlDbType.VarChar).Value = MaterialInfo.addedDate;
                    da.InsertCommand.Parameters.Add("@AddedBy", SqlDbType.VarChar).Value = MaterialInfo.addedBy;
                    sqlCon.Open();

                    da.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                outputMessage = e.Message;
            }

            return outputMessage;
        }

        public List<MaterialModel> Search(MaterialModel MaterialInfo)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(sqlConnectionText))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    MaterialModel materials = null;

                    string sqlCmdText = "SELECT * FROM dbo.MaterialInfo"
                                        + " WHERE ProjectTitle = @ProjectTitle OR IdentificationNumber = @IdentificationNumber OR AddedDate = @AddedDate OR MaterialType = @MaterialType";

                    using (SqlCommand cmd = new SqlCommand(sqlCmdText))
                    {
                        cmd.Connection = sqlCon;
                        sqlCon.Open();
                        DataSet ds = new DataSet();

                        if (MaterialInfo.projectTitle != null)
                        {
                            cmd.Parameters.AddWithValue("@ProjectTitle", MaterialInfo.projectTitle);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ProjectTitle", DBNull.Value);
                        }

                        if (MaterialInfo.IdentificationNumber != 0)
                        {
                            cmd.Parameters.AddWithValue("@IdentificationNumber", MaterialInfo.IdentificationNumber);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@IdentificationNumber", DBNull.Value);
                        }

                        if (MaterialInfo.addedDate != null)
                        {
                            cmd.Parameters.AddWithValue("@AddedDate", MaterialInfo.addedDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@AddedDate", DBNull.Value);
                        }

                        if (MaterialInfo.materialType != null)
                        {
                            cmd.Parameters.AddWithValue("@MaterialType", MaterialInfo.materialType);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@MaterialType", DBNull.Value);
                        }

                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            var values = row.ItemArray;

                            materials = new MaterialModel()
                            {
                                IdentificationNumber = Convert.ToInt32(values[0]),
                                title = values[1].ToString(),
                                projectTitle = values[2].ToString(),
                                materialType = values[3].ToString(),
                                format = values[4].ToString(),
                                audioFormat = values[5].ToString(),
                                runTime = (TimeSpan)(values[6]),
                                releaseDate = Convert.ToDateTime(values[7]),
                                launguage = values[8].ToString(),
                                retailPrice = (float)Convert.ToDouble(values[9]),
                                subTitles = values[10].ToString(),
                                frameAspect = values[11].ToString(),
                                packaging = values[12].ToString(),
                                addedDate = values[13].ToString(),
                                addedBy = values[14].ToString()
                            };
                            lstMaterialsModel.Add(materials);
                        }
                        sqlCon.Close();
                    }                    
                }
            }            
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return lstMaterialsModel;
        }

        public string Update(MaterialModel MaterialInfo)
        {
            string outputMessage = "";
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(sqlConnectionText))
                {
                    SqlDataAdapter da = new SqlDataAdapter();

                    string sqlCmdText = "UPDATE dbo.MaterialInfo SET Title = @Title,ProjectTitle = @ProjectTitle, MaterialType = @MaterialType, Format= @Format,AudioFormat = @AudioFormat,Runtime = @Runtime,ReleaseDate = @ReleaseDate"
                                       + ",Language = @Language ,RetailPrice = @RetailPrice, SubTitles = @SubTitles, FrameAspect = @FrameAspect, Packaging = @Packaging, ModifiedDate = @ModifiedDate" 
                                        + " WHERE IdentificationNumber = @IdentificationNumber";

                    da.UpdateCommand = new SqlCommand(sqlCmdText, sqlCon);
                    da.UpdateCommand.Parameters.Add("@Title", SqlDbType.VarChar).Value = MaterialInfo.title;
                    da.UpdateCommand.Parameters.Add("@ProjectTitle", SqlDbType.VarChar).Value = MaterialInfo.projectTitle;
                    da.UpdateCommand.Parameters.Add("@MaterialType", SqlDbType.VarChar).Value = MaterialInfo.materialType;
                    da.UpdateCommand.Parameters.Add("@Format", SqlDbType.VarChar).Value = MaterialInfo.format;
                    da.UpdateCommand.Parameters.Add("@AudioFormat", SqlDbType.VarChar).Value = MaterialInfo.audioFormat;
                    da.UpdateCommand.Parameters.Add("@Runtime", SqlDbType.Time).Value = MaterialInfo.runTime;
                    da.UpdateCommand.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = MaterialInfo.releaseDate;
                    da.UpdateCommand.Parameters.Add("@Language", SqlDbType.VarChar).Value = MaterialInfo.launguage;
                    da.UpdateCommand.Parameters.Add("@RetailPrice", SqlDbType.Money).Value = MaterialInfo.retailPrice;
                    da.UpdateCommand.Parameters.Add("@SubTitles", SqlDbType.VarChar).Value = MaterialInfo.subTitles;
                    da.UpdateCommand.Parameters.Add("@FrameAspect", SqlDbType.VarChar).Value = MaterialInfo.frameAspect;
                    da.UpdateCommand.Parameters.Add("@Packaging", SqlDbType.VarChar).Value = MaterialInfo.packaging;
                    da.UpdateCommand.Parameters.Add("@IdentificationNumber", SqlDbType.Int).Value = MaterialInfo.IdentificationNumber;
                    da.UpdateCommand.Parameters.Add("@ModifiedDate", SqlDbType.VarChar).Value = System.DateTime.Now.ToString("yyyy-MM-dd");

                    sqlCon.Open();

                    da.UpdateCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                outputMessage = e.Message;
            }
            return outputMessage;
        }

        public string Delete(MaterialModel MaterialInfo)
        {
            string outputMessage = "";
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(sqlConnectionText))
                {
                    SqlDataAdapter da = new SqlDataAdapter();

                    string sqlCmdText = "DELETE FROM dbo.MaterialInfo WHERE IdentificationNumber = @IdentificationNumber";

                    da.DeleteCommand = new SqlCommand(sqlCmdText, sqlCon);
                    da.DeleteCommand.Parameters.Add("@IdentificationNumber", SqlDbType.Int).Value = MaterialInfo.IdentificationNumber;
          
                    sqlCon.Open();

                    da.DeleteCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                outputMessage = e.Message;
            }
            return outputMessage;
        }
    }
}
