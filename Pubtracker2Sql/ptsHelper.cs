﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Pubtracker2Sql.Models;
using Newtonsoft.Json;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Pubtracker2Sql
{
    public class ptsHelper
    {
        public static void ExcecuteSql(string sql)
        { 
           ExecuteNonQueryText(sql, WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString());
        }//End Delete 

        public static void DeletePublication(string pubid)
        {
            List<SqlParameter> myParameters = new List<SqlParameter>();
            SqlParameter s = new SqlParameter();
            s.ParameterName = "PublicationId";
            s.Value = pubid;
            myParameters.Add(s);
            ExecuteNonQueryStoreProc("[pubtrack].[spDeletePublication]", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString(), myParameters);
        }//End Delete publication

        public static void UpdatePublication(ptPublication p)
        {
            List<SqlParameter> myParameters = new List<SqlParameter>();
            SqlParameter s = new SqlParameter();
            s.ParameterName = "@PublicationId";
            s.SqlDbType = SqlDbType.VarChar;
            s.Value = p.PublicationId;
            myParameters.Add(s);
            SqlParameter s1 = new SqlParameter();
            s1.ParameterName = "@SortId";
            s1.SqlDbType = SqlDbType.Int;
            s1.Value = p.SortId;
            myParameters.Add(s1);
            SqlParameter s2 = new SqlParameter();
            s2.ParameterName = "@Title";
            s2.SqlDbType = SqlDbType.VarChar;
            s2.Value = p.Title;
            myParameters.Add(s2);
            SqlParameter s3 = new SqlParameter();
            s3.ParameterName = "@Type";
            s3.SqlDbType = SqlDbType.VarChar;
            s3.Value = JsonConvert.SerializeObject(p.Type);
            myParameters.Add(s3);
            SqlParameter s4 = new SqlParameter();
            s4.ParameterName = "@Series";
            s4.SqlDbType = SqlDbType.VarChar;
            s4.Value = p.Series;
            myParameters.Add(s4);
            SqlParameter s5 = new SqlParameter();
            s5.ParameterName = "@Division";
            s5.SqlDbType = SqlDbType.NVarChar;
            s5.Value = JsonConvert.SerializeObject(p.Division);
            myParameters.Add(s5);
            SqlParameter s6 = new SqlParameter();
            s6.ParameterName = "@Roles";
            s6.SqlDbType = SqlDbType.NVarChar;
            s6.Value = JsonConvert.SerializeObject(p.Roles);
            myParameters.Add(s6);
            SqlParameter s7 = new SqlParameter();
            s7.ParameterName = "@Statuses";
            s7.SqlDbType = SqlDbType.NVarChar;
            s7.Value = JsonConvert.SerializeObject(p.Statuses);
            myParameters.Add(s7);
            SqlParameter s8 = new SqlParameter();
            s8.ParameterName = "@Remarks";
            s6.SqlDbType = SqlDbType.VarChar;
            s8.Value = p.Remarks;
            myParameters.Add(s8);
            ExecuteNonQueryStoreProc("[pubtrack].[spUpdatePublication]", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString(), myParameters);
        }//End Update Publication

        public static void CreatePublication(ptPublication p)
        {
            List<SqlParameter> myParameters = new List<SqlParameter>();
            SqlParameter s = new SqlParameter();
            s.ParameterName = "@PublicationId";
            s.SqlDbType = SqlDbType.VarChar;
            s.Value = p.PublicationId;
            myParameters.Add(s);
            SqlParameter s1 = new SqlParameter();
            s1.ParameterName = "@SortId";
            s1.SqlDbType = SqlDbType.Int;
            s1.Value = p.SortId;
            myParameters.Add(s1);
            SqlParameter s2 = new SqlParameter();
            s2.ParameterName = "@Title";
            s2.SqlDbType = SqlDbType.VarChar;
            s2.Value = p.Title;
            myParameters.Add(s2);
            SqlParameter s3 = new SqlParameter();
            s3.ParameterName = "@Type";
            s3.SqlDbType = SqlDbType.VarChar;
            s3.Value = JsonConvert.SerializeObject(p.Type);
            myParameters.Add(s3);
            SqlParameter s4 = new SqlParameter();
            s4.ParameterName = "@Series";
            s4.SqlDbType = SqlDbType.VarChar;
            s4.Value = p.Series;
            myParameters.Add(s4);
            SqlParameter s5 = new SqlParameter();
            s5.ParameterName = "@Division";
            s5.SqlDbType = SqlDbType.NVarChar;
            s5.Value = JsonConvert.SerializeObject(p.Division);
            myParameters.Add(s5);
            SqlParameter s6 = new SqlParameter();
            s6.ParameterName = "@Roles";
            s6.SqlDbType = SqlDbType.NVarChar;
            s6.Value = JsonConvert.SerializeObject(p.Roles);
            myParameters.Add(s6);
            SqlParameter s7 = new SqlParameter();
            s7.ParameterName = "@Statuses";
            s7.SqlDbType = SqlDbType.NVarChar;
            s7.Value = JsonConvert.SerializeObject(p.Statuses);
            myParameters.Add(s7);
            SqlParameter s8 = new SqlParameter();
            s8.ParameterName = "@Remarks";
            s6.SqlDbType = SqlDbType.VarChar;
            s8.Value = p.Remarks;
            myParameters.Add(s8);
            ExecuteNonQueryStoreProc("[pubtrack].[spInsertPublication]", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString(), myParameters);
        }//End Create Publication

        public static string GetAllPublicationsAsJson()
        {
            List<ptPublication> items = GetAllPublications();
            return JsonConvert.SerializeObject(items.OrderByDescending(x => x.SortId).Take(10));
        }//End GetOne

        public static string GetOnePublicationAsJson(string pubid)
        {
            List<ptPublication> items = GetAllPublications();
            ptPublication item = items.Find(x => x.PublicationId == pubid);
            return JsonConvert.SerializeObject(item);
        }//End GetAll

        public static List<ptDivision> GetAllDivisions()
        {
            List<ptDivision> items = new List<ptDivision>();

            DataSet ds = ExecuteSPDataSetText("Divisions", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString());
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ptDivision item = new ptDivision();
                item.DivisionId = r["DivisionId"].ToString();
                item.DivisionName = r["DivisionName"].ToString();
                item.Active = Convert.ToBoolean(r["Active"].ToString());
                items.Add(item);
            }
            return items;
        }//End GetAll Divisions

        public static List<ptRole> GetAllRoles()
        {
            List<ptRole> items = new List<ptRole>();

            DataSet ds = ExecuteSPDataSetText("Roles", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString());
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ptRole item = new ptRole();
                item.RoleId = r["RoleId"].ToString();
                item.RoleName = r["RoleName"].ToString();
                item.Active = Convert.ToBoolean(r["Active"].ToString());
                items.Add(item);
            }
            return items;
        }//End GetAll Roles

        public static List<ptStep> GetAllSteps()
        {
            List<ptStep> items = new List<ptStep>();

            DataSet ds = ExecuteSPDataSetText("Steps", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString());
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ptStep item = new ptStep();
                item.StepId = r["StepId"].ToString();
                item.StepName = r["StepName"].ToString();
                item.Active = Convert.ToBoolean(r["Active"].ToString());
                items.Add(item);
            }
            return items;
        }//End GetAll Steps

        public static List<ptType> GetAllTypes()
        {
            List<ptType> items = new List<ptType>();

            DataSet ds = ExecuteSPDataSetText("Types", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString());
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ptType item = new ptType();
                item.TypeId = r["TypeId"].ToString();
                item.TypeName = r["TypeName"].ToString();
                item.Active = Convert.ToBoolean(r["Active"].ToString());
                items.Add(item);
            }
            return items;
        }//End GetAll Types

        public static List<ptUser> GetAllUsers()
        {
            List<ptUser> items = new List<ptUser>();

            DataSet ds = ExecuteSPDataSetText("Users", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString());
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ptUser item = new ptUser();
                item.UserId = r["UserId"].ToString();
                item.FirstName = r["FirstName"].ToString();
                item.LastName = r["LastName"].ToString();
                item.Active = Convert.ToBoolean(r["Active"].ToString());
                items.Add(item);
            }
            return items;
        }//End GetAll Users

        public static List<ptPublication> GetAllPublications()
        {
            List<SqlParameter> myParameters = new List<SqlParameter>();
            List<ptPublication> items = new List<ptPublication>();
            
            DataSet ds = ExecuteSPDataSet("[pubtrack].[spSelectPublication]", WebConfigurationManager.ConnectionStrings["pubtrackdev"].ConnectionString.ToString(), myParameters);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ptPublication item = new ptPublication();
                item.PublicationId = r["PublicationId"].ToString();
                item.SortId = Convert.ToInt32(r["SortId"].ToString());
                item.Title = r["Title"].ToString();
                item.Type = JsonConvert.DeserializeObject<ptType>(r["Type"].ToString());
                item.Series = r["Series"].ToString();
                item.Division = JsonConvert.DeserializeObject<ptDivision>(r["Division"].ToString());
                item.Roles = JsonConvert.DeserializeObject<List<ptRoles>>(r["Roles"].ToString());
                item.Statuses = JsonConvert.DeserializeObject<List<ptStatus>>(r["Statuses"].ToString());
                item.Remarks = r["Remarks"].ToString();
                items.Add(item);
            }
            return items;
        }//End GetAll

    private static DataSet ExecuteSPDataSet(string ProcName, string ConnString, List<SqlParameter> InputParms)
    {
        DataSet dataSet = new DataSet();
        using (SqlConnection SqlConn = new SqlConnection(ConnString))
        {
            SqlCommand Sqlcommand = new SqlCommand(ProcName, SqlConn);
            Sqlcommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter sp in InputParms)
            {
                Sqlcommand.Parameters.Add(sp);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(Sqlcommand);
            SqlConn.Open();
            adapter.Fill(dataSet);
        }//using
        return dataSet;
    }//End ExecuteSPDataSet


        private static DataSet ExecuteSPDataSetText(string area, string ConnString)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                string sql = "Select * from pubtrack.tbl" + area + ";"; 
                SqlCommand Sqlcommand = new SqlCommand(sql, SqlConn);
                Sqlcommand.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(Sqlcommand);
                SqlConn.Open();
                adapter.Fill(dataSet);
            }//using
            return dataSet;
        }//End ExecuteSPDataSet
        private static void ExecuteNonQueryStoreProc(string ProcName, string ConnString, List<SqlParameter> InputParms)
    {
        using (SqlConnection SqlConn = new SqlConnection(ConnString))
        {
            SqlCommand Sqlcommand = new SqlCommand(ProcName, SqlConn);
            Sqlcommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sp in InputParms)
                {
                    Sqlcommand.Parameters.Add(sp);
                }
                Sqlcommand.CommandTimeout = 0;
            SqlConn.Open();
            int rows = Sqlcommand.ExecuteNonQuery();
        }//using
    }// End ExecuteNonQuery Stored Proc
        private static void ExecuteNonQueryText(string sql, string ConnString)
        {
            using (SqlConnection SqlConn = new SqlConnection(ConnString))
            {
                SqlCommand Sqlcommand = new SqlCommand(sql, SqlConn);
                Sqlcommand.CommandType = CommandType.Text;
                Sqlcommand.CommandTimeout = 0;
                SqlConn.Open();
                int rows = Sqlcommand.ExecuteNonQuery();
            }//using
        }// End ExecuteNonQuery Text
    }// End Class
}// End Namespace