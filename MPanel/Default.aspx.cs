using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MPanel
{
    public partial class _Default : System.Web.UI.Page
    {
        private static readonly int[] _pollIntervals = { 10000, 15000, 25000 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            gvHosts.DataSource = HostRepository.GetAll();
            gvHosts.DataBind();
        }

        protected void btnAddHost_Click(object sender, EventArgs e)
        {
            string ipAddress = txtIPAddress.Text.Trim();
            string port = txtPort.Text.Trim();
            if (!string.IsNullOrEmpty(ipAddress) && !string.IsNullOrEmpty(port))
            {
                HostRepository.Add(ipAddress, port, txtAdditionalInfo.Text.Trim());

                BindGrid();
                txtIPAddress.Text = string.Empty;
                txtPort.Text = string.Empty;
                txtAdditionalInfo.Text = string.Empty;
            }
        }

        protected void gvHosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHosts.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvHosts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHosts.EditIndex = -1;
            BindGrid();
        }

        protected void gvHosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ipAddress = gvHosts.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = gvHosts.Rows[e.RowIndex];
            string additionalInfo = ((TextBox)row.FindControl("txtEditAdditionalInfo")).Text.Trim();

            HostRepository.Update(ipAddress, additionalInfo);

            gvHosts.EditIndex = -1;
            BindGrid();
        }

        protected void gvHosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ipAddress = gvHosts.DataKeys[e.RowIndex].Value.ToString();
            HostRepository.Delete(ipAddress);
            BindGrid();
        }
    }
}