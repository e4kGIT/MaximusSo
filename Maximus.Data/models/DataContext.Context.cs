﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maximus.Data.models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class e4kmaximusdbEntities : DbContext
    {
        public e4kmaximusdbEntities()
            : base("name=e4kmaximusdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<copy_my_aspnet_membership> copy_my_aspnet_membership { get; set; }
        public virtual DbSet<copy_tblusers> copy_tblusers { get; set; }
        public virtual DbSet<cxml_salesorder_detail> cxml_salesorder_detail { get; set; }
        public virtual DbSet<cxml_salesorder_header> cxml_salesorder_header { get; set; }
        public virtual DbSet<hr_address_duplicate_min> hr_address_duplicate_min { get; set; }
        public virtual DbSet<hr_business_removed> hr_business_removed { get; set; }
        public virtual DbSet<hr_cargo_sizes> hr_cargo_sizes { get; set; }
        public virtual DbSet<hr_change_business> hr_change_business { get; set; }
        public virtual DbSet<hr_cordant_address> hr_cordant_address { get; set; }
        public virtual DbSet<hr_cordant_assembly> hr_cordant_assembly { get; set; }
        public virtual DbSet<hr_cordant_managers> hr_cordant_managers { get; set; }
        public virtual DbSet<hr_cordant_onl_emp> hr_cordant_onl_emp { get; set; }
        public virtual DbSet<hr_cordant_user> hr_cordant_user { get; set; }
        public virtual DbSet<hr_cordant_user_copy> hr_cordant_user_copy { get; set; }
        public virtual DbSet<hr_corps01_employee> hr_corps01_employee { get; set; }
        public virtual DbSet<hr_emplo_ve> hr_emplo_ve { get; set; }
        public virtual DbSet<hr_emplo_ve_copy> hr_emplo_ve_copy { get; set; }
        public virtual DbSet<hr_emplo_ve_copy_duplicate> hr_emplo_ve_copy_duplicate { get; set; }
        public virtual DbSet<hr_emplo_ve_ma> hr_emplo_ve_ma { get; set; }
        public virtual DbSet<hr_employee_to_branch> hr_employee_to_branch { get; set; }
        public virtual DbSet<hr_morders> hr_morders { get; set; }
        public virtual DbSet<hr_onlineorder_deleted> hr_onlineorder_deleted { get; set; }
        public virtual DbSet<hr_price_update> hr_price_update { get; set; }
        public virtual DbSet<hr_pwc> hr_pwc { get; set; }
        public virtual DbSet<hr_pwc_locations> hr_pwc_locations { get; set; }
        public virtual DbSet<hr_pwc_size> hr_pwc_size { get; set; }
        public virtual DbSet<hr_rollout_styles> hr_rollout_styles { get; set; }
        public virtual DbSet<hr_rollout_styles_copy> hr_rollout_styles_copy { get; set; }
        public virtual DbSet<hr_s27_name> hr_s27_name { get; set; }
        public virtual DbSet<hr_salesorder_deleted> hr_salesorder_deleted { get; set; }
        public virtual DbSet<hr_sohead> hr_sohead { get; set; }
        public virtual DbSet<hr_style_prices> hr_style_prices { get; set; }
        public virtual DbSet<hr_tremot02> hr_tremot02 { get; set; }
        public virtual DbSet<hr_tsb_2020_custref_change> hr_tsb_2020_custref_change { get; set; }
        public virtual DbSet<hr_tsb_delivery_day> hr_tsb_delivery_day { get; set; }
        public virtual DbSet<hr_tsb_delivery_schedule> hr_tsb_delivery_schedule { get; set; }
        public virtual DbSet<hr_tsb_leavers> hr_tsb_leavers { get; set; }
        public virtual DbSet<hr_tsb_leavers_2019> hr_tsb_leavers_2019 { get; set; }
        public virtual DbSet<hr_tsb_leavers_2019_final> hr_tsb_leavers_2019_final { get; set; }
        public virtual DbSet<hr_tsb_reldates> hr_tsb_reldates { get; set; }
        public virtual DbSet<hr_tsb_release> hr_tsb_release { get; set; }
        public virtual DbSet<hr_tsb_ucodes> hr_tsb_ucodes { get; set; }
        public virtual DbSet<ht_kbus> ht_kbus { get; set; }
        public virtual DbSet<ht_tsb_2020_custref_change> ht_tsb_2020_custref_change { get; set; }
        public virtual DbSet<my_aspnet_applications> my_aspnet_applications { get; set; }
        public virtual DbSet<my_aspnet_membership> my_aspnet_membership { get; set; }
        public virtual DbSet<my_aspnet_paths> my_aspnet_paths { get; set; }
        public virtual DbSet<my_aspnet_personalizationallusers> my_aspnet_personalizationallusers { get; set; }
        public virtual DbSet<my_aspnet_personalizationperuser> my_aspnet_personalizationperuser { get; set; }
        public virtual DbSet<my_aspnet_profiles> my_aspnet_profiles { get; set; }
        public virtual DbSet<my_aspnet_roles> my_aspnet_roles { get; set; }
        public virtual DbSet<my_aspnet_sessioncleanup> my_aspnet_sessioncleanup { get; set; }
        public virtual DbSet<my_aspnet_sessions> my_aspnet_sessions { get; set; }
        public virtual DbSet<my_aspnet_sitemap> my_aspnet_sitemap { get; set; }
        public virtual DbSet<my_aspnet_users> my_aspnet_users { get; set; }
        public virtual DbSet<my_aspnet_usersinroles> my_aspnet_usersinroles { get; set; }
        public virtual DbSet<tbl_employee_s27_hr> tbl_employee_s27_hr { get; set; }
        public virtual DbSet<tblacc_vatcodes> tblacc_vatcodes { get; set; }
        public virtual DbSet<tblaccemp_budget> tblaccemp_budget { get; set; }
        public virtual DbSet<tblaccemp_budgetcard> tblaccemp_budgetcard { get; set; }
        public virtual DbSet<tblaccemp_departments> tblaccemp_departments { get; set; }
        public virtual DbSet<tblaccemp_employee> tblaccemp_employee { get; set; }
        public virtual DbSet<tblaccemp_employee_atlasfm> tblaccemp_employee_atlasfm { get; set; }
        public virtual DbSet<tblaccemp_employee_copy> tblaccemp_employee_copy { get; set; }
        public virtual DbSet<tblaccemp_employee_rollout> tblaccemp_employee_rollout { get; set; }
        public virtual DbSet<tblaccemp_employee_rollout_atlasfm> tblaccemp_employee_rollout_atlasfm { get; set; }
        public virtual DbSet<tblaccemp_employee_rollout_copy> tblaccemp_employee_rollout_copy { get; set; }
        public virtual DbSet<tblaccemp_employees_custref> tblaccemp_employees_custref { get; set; }
        public virtual DbSet<tblaccemp_points> tblaccemp_points { get; set; }
        public virtual DbSet<tblaccemp_pointsadjustment> tblaccemp_pointsadjustment { get; set; }
        public virtual DbSet<tblaccemp_pointscard> tblaccemp_pointscard { get; set; }
        public virtual DbSet<tblaccemp_rollout_email> tblaccemp_rollout_email { get; set; }
        public virtual DbSet<tblaccemp_rollout_names> tblaccemp_rollout_names { get; set; }
        public virtual DbSet<tblaccemp_rollout_ucode_ref> tblaccemp_rollout_ucode_ref { get; set; }
        public virtual DbSet<tblaccemp_stockcard> tblaccemp_stockcard { get; set; }
        public virtual DbSet<tblaccemp_stockcard_atlasfm> tblaccemp_stockcard_atlasfm { get; set; }
        public virtual DbSet<tblaccemp_stockcard_atlasfm_> tblaccemp_stockcard_atlasfm_ { get; set; }
        public virtual DbSet<tblaccemp_stockcard_copy> tblaccemp_stockcard_copy { get; set; }
        public virtual DbSet<tblaccemp_stylepoints> tblaccemp_stylepoints { get; set; }
        public virtual DbSet<tblaccemp_ucode_reasons> tblaccemp_ucode_reasons { get; set; }
        public virtual DbSet<tblaccemp_ucodepoints> tblaccemp_ucodepoints { get; set; }
        public virtual DbSet<tblaccemp_ucodes> tblaccemp_ucodes { get; set; }
        public virtual DbSet<tblaccemp_ucodes_desc> tblaccemp_ucodes_desc { get; set; }
        public virtual DbSet<tblaccemp_ucodes_dimension> tblaccemp_ucodes_dimension { get; set; }
        public virtual DbSet<tblaccemp_ucodes_hours> tblaccemp_ucodes_hours { get; set; }
        public virtual DbSet<tblaccemp_ucodesemployees> tblaccemp_ucodesemployees { get; set; }
        public virtual DbSet<tblaccemp_ucodesemployees_atlasfm> tblaccemp_ucodesemployees_atlasfm { get; set; }
        public virtual DbSet<tblaccesslevel> tblaccesslevels { get; set; }
        public virtual DbSet<tbladmin> tbladmins { get; set; }
        public virtual DbSet<tblasm_assemblydetail> tblasm_assemblydetail { get; set; }
        public virtual DbSet<tblasm_assemblyheader> tblasm_assemblyheader { get; set; }
        public virtual DbSet<tblbus_account> tblbus_account { get; set; }
        public virtual DbSet<tblbus_address> tblbus_address { get; set; }
        public virtual DbSet<tblbus_addresstype_ref> tblbus_addresstype_ref { get; set; }
        public virtual DbSet<tblbus_addresstypes> tblbus_addresstypes { get; set; }
        public virtual DbSet<tblbus_business> tblbus_business { get; set; }
        public virtual DbSet<tblbus_business_types> tblbus_business_types { get; set; }
        public virtual DbSet<tblbus_contact> tblbus_contact { get; set; }
        public virtual DbSet<tblbus_contact_copy> tblbus_contact_copy { get; set; }
        public virtual DbSet<tblbus_contact_ref> tblbus_contact_ref { get; set; }
        public virtual DbSet<tblbus_countrycodes> tblbus_countrycodes { get; set; }
        public virtual DbSet<tblbus_groups_ref> tblbus_groups_ref { get; set; }
        public virtual DbSet<tblbus_online_orderref_nominal> tblbus_online_orderref_nominal { get; set; }
        public virtual DbSet<tblbus_settings> tblbus_settings { get; set; }
        public virtual DbSet<tblbus_setvalues> tblbus_setvalues { get; set; }
        public virtual DbSet<tblbus_styles> tblbus_styles { get; set; }
        public virtual DbSet<tblchildmenu> tblchildmenus { get; set; }
        public virtual DbSet<tblchildmenu_new> tblchildmenu_new { get; set; }
        public virtual DbSet<tblchildmenu_newlayout> tblchildmenu_newlayout { get; set; }
        public virtual DbSet<tblchildmenu_newlayout_newsystem> tblchildmenu_newlayout_newsystem { get; set; }
        public virtual DbSet<tblcmp_defaults> tblcmp_defaults { get; set; }
        public virtual DbSet<tblcompany> tblcompanies { get; set; }
        public virtual DbSet<tblcontent_lang> tblcontent_lang { get; set; }
        public virtual DbSet<tblfsk_class> tblfsk_class { get; set; }
        public virtual DbSet<tblfsk_colour> tblfsk_colour { get; set; }
        public virtual DbSet<tblfsk_features> tblfsk_features { get; set; }
        public virtual DbSet<tblfsk_price> tblfsk_price { get; set; }
        public virtual DbSet<tblfsk_seasons> tblfsk_seasons { get; set; }
        public virtual DbSet<tblfsk_settings> tblfsk_settings { get; set; }
        public virtual DbSet<tblfsk_setvalues> tblfsk_setvalues { get; set; }
        public virtual DbSet<tblfsk_style> tblfsk_style { get; set; }
        public virtual DbSet<tblfsk_style_colour> tblfsk_style_colour { get; set; }
        public virtual DbSet<tblfsk_style_colour_size> tblfsk_style_colour_size { get; set; }
        public virtual DbSet<tblfsk_style_colour_size_obsolete> tblfsk_style_colour_size_obsolete { get; set; }
        public virtual DbSet<tblfsk_style_commoditycode> tblfsk_style_commoditycode { get; set; }
        public virtual DbSet<tblfsk_style_customers> tblfsk_style_customers { get; set; }
        public virtual DbSet<tblfsk_style_freetext> tblfsk_style_freetext { get; set; }
        public virtual DbSet<tblfsk_style_gallery> tblfsk_style_gallery { get; set; }
        public virtual DbSet<tblfsk_style_groups> tblfsk_style_groups { get; set; }
        public virtual DbSet<tblfsk_style_groups_sub> tblfsk_style_groups_sub { get; set; }
        public virtual DbSet<tblfsk_style_locations> tblfsk_style_locations { get; set; }
        public virtual DbSet<tblfsk_style_reps> tblfsk_style_reps { get; set; }
        public virtual DbSet<tblfsk_style_sizes> tblfsk_style_sizes { get; set; }
        public virtual DbSet<tblfsk_style_sizes_prices> tblfsk_style_sizes_prices { get; set; }
        public virtual DbSet<tblfsk_style_stock_levels> tblfsk_style_stock_levels { get; set; }
        public virtual DbSet<tblfsk_style_stockingtypes> tblfsk_style_stockingtypes { get; set; }
        public virtual DbSet<tblfsk_style_typeofissue> tblfsk_style_typeofissue { get; set; }
        public virtual DbSet<tblfsk_unitofmeasure> tblfsk_unitofmeasure { get; set; }
        public virtual DbSet<tblfsk_unitofmeasure_customer> tblfsk_unitofmeasure_customer { get; set; }
        public virtual DbSet<tblfsk_unitofmeasureconversion> tblfsk_unitofmeasureconversion { get; set; }
        public virtual DbSet<tblfsk_unspsc_customer> tblfsk_unspsc_customer { get; set; }
        public virtual DbSet<tblfskstyle_dimension> tblfskstyle_dimension { get; set; }
        public virtual DbSet<tblfskstyle_dimension1_> tblfskstyle_dimension1_ { get; set; }
        public virtual DbSet<tblfstk_feature> tblfstk_feature { get; set; }
        public virtual DbSet<tblfstk_featureoption_type> tblfstk_featureoption_type { get; set; }
        public virtual DbSet<tblgen_autonumbers> tblgen_autonumbers { get; set; }
        public virtual DbSet<tblgen_log> tblgen_log { get; set; }
        public virtual DbSet<tblgen_nextno> tblgen_nextno { get; set; }
        public virtual DbSet<tblgen_parameters> tblgen_parameters { get; set; }
        public virtual DbSet<tblgen_user_defaults> tblgen_user_defaults { get; set; }
        public virtual DbSet<tblgen_user_parameters> tblgen_user_parameters { get; set; }
        public virtual DbSet<tblgen_user_parameters_copy> tblgen_user_parameters_copy { get; set; }
        public virtual DbSet<tblgen_users> tblgen_users { get; set; }
        public virtual DbSet<tbllanguage> tbllanguages { get; set; }
        public virtual DbSet<tblonline_holidays> tblonline_holidays { get; set; }
        public virtual DbSet<tblonline_rejectorder_reasons> tblonline_rejectorder_reasons { get; set; }
        public virtual DbSet<tblonline_rejectorder_ucodes> tblonline_rejectorder_ucodes { get; set; }
        public virtual DbSet<tblonline_rolloutorders_config> tblonline_rolloutorders_config { get; set; }
        public virtual DbSet<tblonline_rolloutorders_reqstatus> tblonline_rolloutorders_reqstatus { get; set; }
        public virtual DbSet<tblonline_rolloutorders_reqstatus_atlasfm> tblonline_rolloutorders_reqstatus_atlasfm { get; set; }
        public virtual DbSet<tblonline_userid_employee> tblonline_userid_employee { get; set; }
        public virtual DbSet<tblonline_userid_employee_atlasfm> tblonline_userid_employee_atlasfm { get; set; }
        public virtual DbSet<tblonline_userid_favourites> tblonline_userid_favourites { get; set; }
        public virtual DbSet<tblonlinebus_carriage> tblonlinebus_carriage { get; set; }
        public virtual DbSet<tblonlinesop_carriage> tblonlinesop_carriage { get; set; }
        public virtual DbSet<tblonlinesop_sitecode> tblonlinesop_sitecode { get; set; }
        public virtual DbSet<tblparentmenu> tblparentmenus { get; set; }
        public virtual DbSet<tblparentmenu_new> tblparentmenu_new { get; set; }
        public virtual DbSet<tblparentmenu_newlayout> tblparentmenu_newlayout { get; set; }
        public virtual DbSet<tblparentmenu_newlayout_newsystem> tblparentmenu_newlayout_newsystem { get; set; }
        public virtual DbSet<tblpayment_gateways> tblpayment_gateways { get; set; }
        public virtual DbSet<tblpayment_trans> tblpayment_trans { get; set; }
        public virtual DbSet<tblpermission_controls> tblpermission_controls { get; set; }
        public virtual DbSet<tblpermission_controls_category> tblpermission_controls_category { get; set; }
        public virtual DbSet<tblpermission_settings> tblpermission_settings { get; set; }
        public virtual DbSet<tblpermission_settings_users> tblpermission_settings_users { get; set; }
        public virtual DbSet<tblpermission_users_allow> tblpermission_users_allow { get; set; }
        public virtual DbSet<tblpermission_users_deny> tblpermission_users_deny { get; set; }
        public virtual DbSet<tblquestionanswer> tblquestionanswers { get; set; }
        public virtual DbSet<tblrep_kams> tblrep_kams { get; set; }
        public virtual DbSet<tblsap_log> tblsap_log { get; set; }
        public virtual DbSet<tblsop_carrier> tblsop_carrier { get; set; }
        public virtual DbSet<tblsop_courier_information> tblsop_courier_information { get; set; }
        public virtual DbSet<tblsop_customer_ref> tblsop_customer_ref { get; set; }
        public virtual DbSet<tblsop_customerorder_template> tblsop_customerorder_template { get; set; }
        public virtual DbSet<tblsop_customerorder_template_costcentre> tblsop_customerorder_template_costcentre { get; set; }
        public virtual DbSet<tblsop_customerorder_template_img> tblsop_customerorder_template_img { get; set; }
        public virtual DbSet<tblsop_customerorder_template_ucodes> tblsop_customerorder_template_ucodes { get; set; }
        public virtual DbSet<tblsop_despatch_confirm> tblsop_despatch_confirm { get; set; }
        public virtual DbSet<tblsop_despatch_status> tblsop_despatch_status { get; set; }
        public virtual DbSet<tblsop_download_fields> tblsop_download_fields { get; set; }
        public virtual DbSet<tblsop_invoice_detail> tblsop_invoice_detail { get; set; }
        public virtual DbSet<tblsop_invoice_header> tblsop_invoice_header { get; set; }
        public virtual DbSet<tblsop_manpackorders> tblsop_manpackorders { get; set; }
        public virtual DbSet<tblsop_manpackreturns> tblsop_manpackreturns { get; set; }
        public virtual DbSet<tblsop_pickingslip_detail> tblsop_pickingslip_detail { get; set; }
        public virtual DbSet<tblsop_pickingslip_header> tblsop_pickingslip_header { get; set; }
        public virtual DbSet<tblsop_reasoncodes> tblsop_reasoncodes { get; set; }
        public virtual DbSet<tblsop_reasons> tblsop_reasons { get; set; }
        public virtual DbSet<tblsop_return_reasoncodes> tblsop_return_reasoncodes { get; set; }
        public virtual DbSet<tblsop_return_reasoncodes_customer> tblsop_return_reasoncodes_customer { get; set; }
        public virtual DbSet<tblsop_salesorder_approved> tblsop_salesorder_approved { get; set; }
        public virtual DbSet<tblsop_salesorder_detail> tblsop_salesorder_detail { get; set; }
        public virtual DbSet<tblsop_salesorder_detail_atlasfm> tblsop_salesorder_detail_atlasfm { get; set; }
        public virtual DbSet<tblsop_salesorder_detail_offline> tblsop_salesorder_detail_offline { get; set; }
        public virtual DbSet<tblsop_salesorder_header> tblsop_salesorder_header { get; set; }
        public virtual DbSet<tblsop_salesorder_header_atlasfm> tblsop_salesorder_header_atlasfm { get; set; }
        public virtual DbSet<tblsop_salesorder_header_offline> tblsop_salesorder_header_offline { get; set; }
        public virtual DbSet<tblsqlstring> tblsqlstrings { get; set; }
        public virtual DbSet<tblupdate_status_three> tblupdate_status_three { get; set; }
        public virtual DbSet<tbluser> tblusers { get; set; }
        public virtual DbSet<tblwho_warehouses> tblwho_warehouses { get; set; }
        public virtual DbSet<tblwho_warehousesx> tblwho_warehousesx { get; set; }
        public virtual DbSet<xml_salesorder_detail> xml_salesorder_detail { get; set; }
        public virtual DbSet<xml_salesorder_header> xml_salesorder_header { get; set; }
        public virtual DbSet<bak_tblaccemp_employee_tsb> bak_tblaccemp_employee_tsb { get; set; }
        public virtual DbSet<hr_demo_address> hr_demo_address { get; set; }
        public virtual DbSet<hr_demo_employee> hr_demo_employee { get; set; }
        public virtual DbSet<hr_demo_invoices> hr_demo_invoices { get; set; }
        public virtual DbSet<hr_demo_orders> hr_demo_orders { get; set; }
        public virtual DbSet<hr_demo_pickslips> hr_demo_pickslips { get; set; }
        public virtual DbSet<hr_demo_style> hr_demo_style { get; set; }
        public virtual DbSet<hr_demo_ucode> hr_demo_ucode { get; set; }
        public virtual DbSet<hr_s27_adcpvt_lines> hr_s27_adcpvt_lines { get; set; }
        public virtual DbSet<hr_s27_empucode> hr_s27_empucode { get; set; }
        public virtual DbSet<hr_s27_order_adjust> hr_s27_order_adjust { get; set; }
        public virtual DbSet<hr_s27_pwt_lines> hr_s27_pwt_lines { get; set; }
        public virtual DbSet<hr_s27_rollout_order_delete> hr_s27_rollout_order_delete { get; set; }
        public virtual DbSet<hr_s7_pwt_assmblylines> hr_s7_pwt_assmblylines { get; set; }
        public virtual DbSet<hr_sohead_copy> hr_sohead_copy { get; set; }
        public virtual DbSet<hr_tsb_min_orderdate> hr_tsb_min_orderdate { get; set; }
        public virtual DbSet<hr_tsb_new_delday> hr_tsb_new_delday { get; set; }
        public virtual DbSet<hr_tsb_tblaccemp_ucodesemployees> hr_tsb_tblaccemp_ucodesemployees { get; set; }
        public virtual DbSet<hr_tsbban01_partner_convert> hr_tsbban01_partner_convert { get; set; }
        public virtual DbSet<hr_users_removed> hr_users_removed { get; set; }
        public virtual DbSet<hr_visexp01_dimfit_style> hr_visexp01_dimfit_style { get; set; }
        public virtual DbSet<rollout_order_detail_tsb> rollout_order_detail_tsb { get; set; }
        public virtual DbSet<rollout_order_header_address_tsb> rollout_order_header_address_tsb { get; set; }
        public virtual DbSet<rollout_order_header_tsb> rollout_order_header_tsb { get; set; }
        public virtual DbSet<stockcard_tsb_rollout> stockcard_tsb_rollout { get; set; }
        public virtual DbSet<tblaccemp_employee_hr> tblaccemp_employee_hr { get; set; }
        public virtual DbSet<tblaccemp_employee_hr_level1> tblaccemp_employee_hr_level1 { get; set; }
        public virtual DbSet<tblaccemp_employee_hr_level2> tblaccemp_employee_hr_level2 { get; set; }
        public virtual DbSet<tblaccemp_style_staticqty> tblaccemp_style_staticqty { get; set; }
        public virtual DbSet<tblonlinesop_backorders> tblonlinesop_backorders { get; set; }
        public virtual DbSet<tblsop_salesorder_detail_console> tblsop_salesorder_detail_console { get; set; }
        public virtual DbSet<tblsop_salesorder_header_console> tblsop_salesorder_header_console { get; set; }
        public virtual DbSet<tblupload_orderdetail> tblupload_orderdetail { get; set; }
        public virtual DbSet<tblupload_orderheader> tblupload_orderheader { get; set; }
        public virtual DbSet<ucode_employee_rollout_tsb> ucode_employee_rollout_tsb { get; set; }
        public virtual DbSet<dim_fit_nongroup_styles> dim_fit_nongroup_styles { get; set; }
        public virtual DbSet<dim_fit_styles> dim_fit_styles { get; set; }
        public virtual DbSet<getallassembly> getallassemblies { get; set; }
        public virtual DbSet<getcolour> getcolours { get; set; }
        public virtual DbSet<getcustassembly> getcustassemblies { get; set; }
        public virtual DbSet<getproductslist> getproductslists { get; set; }
        public virtual DbSet<getsize> getsizes { get; set; }
        public virtual DbSet<getstylesview> getstylesviews { get; set; }
        public virtual DbSet<product_obsolete> product_obsolete { get; set; }
        public virtual DbSet<productlist> productlists { get; set; }
        public virtual DbSet<style_dimfitalloc_caption> style_dimfitalloc_caption { get; set; }
        public virtual DbSet<styleby_freetextview> styleby_freetextview { get; set; }
        public virtual DbSet<styleby_freetextview_emergency> styleby_freetextview_emergency { get; set; }
        public virtual DbSet<styleby_freetextview_ucode> styleby_freetextview_ucode { get; set; }
        public virtual DbSet<stylebytemplateview> stylebytemplateviews { get; set; }
        public virtual DbSet<tblfskstyle_dimension1> tblfskstyle_dimension1 { get; set; }
        public virtual DbSet<ucodeby_freetextview> ucodeby_freetextview { get; set; }
        public virtual DbSet<unrelatedorder> unrelatedorders { get; set; }
        public virtual DbSet<view_manpack> view_manpack { get; set; }
        public virtual DbSet<view_noorderplacedforthisemployee> view_noorderplacedforthisemployee { get; set; }
        public virtual DbSet<view_normatucodereissueorder> view_normatucodereissueorder { get; set; }
        public virtual DbSet<view_order_freetext_tsb_rollout> view_order_freetext_tsb_rollout { get; set; }
        public virtual DbSet<view_privateorder_pendings> view_privateorder_pendings { get; set; }
        public virtual DbSet<view_privateorders> view_privateorders { get; set; }
        public virtual DbSet<view_reissueorderwithnormalucode> view_reissueorderwithnormalucode { get; set; }
        public virtual DbSet<view_totalpointsused> view_totalpointsused { get; set; }
        public virtual DbSet<view_ucode_freetext_tsb_rollout> view_ucode_freetext_tsb_rollout { get; set; }
        public virtual DbSet<view_unmatchedcolourwithorgcolour> view_unmatchedcolourwithorgcolour { get; set; }
        public virtual DbSet<view_unmatchedordercolourid> view_unmatchedordercolourid { get; set; }
        public virtual DbSet<tblonline_ucode_operations> tblonline_ucode_operations { get; set; }
    
        public virtual int bk_CreateCube_OrderDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("bk_CreateCube_OrderDetail");
        }
    
        public virtual int CreateCube_EmployeeCard()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateCube_EmployeeCard");
        }
    
        public virtual int CreateCube_OrderDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateCube_OrderDetail");
        }
    
        public virtual int CreateCube_OrderStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateCube_OrderStatus");
        }
    
        public virtual int createcube_stocklevels()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createcube_stocklevels");
        }
    
        public virtual int createCube_summary()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createCube_summary");
        }
    
        public virtual int create_all_cubes1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("create_all_cubes1");
        }
    
        public virtual int create_all_cubes2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("create_all_cubes2");
        }
    
        public virtual ObjectResult<GetAllUcodeByFreeTextProcedure_Result> GetAllUcodeByFreeTextProcedure(string uCode)
        {
            var uCodeParameter = uCode != null ?
                new ObjectParameter("uCode", uCode) :
                new ObjectParameter("uCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUcodeByFreeTextProcedure_Result>("GetAllUcodeByFreeTextProcedure", uCodeParameter);
        }
    
        public virtual ObjectResult<getColorProcedure_Result> getColorProcedure(string style)
        {
            var styleParameter = style != null ?
                new ObjectParameter("style", style) :
                new ObjectParameter("style", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getColorProcedure_Result>("getColorProcedure", styleParameter);
        }
    
        public virtual ObjectResult<getColors_Result> getColors(string style)
        {
            var styleParameter = style != null ?
                new ObjectParameter("style", style) :
                new ObjectParameter("style", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getColors_Result>("getColors", styleParameter);
        }
    
        public virtual ObjectResult<getColors_prod_Result> getColors_prod(string style)
        {
            var styleParameter = style != null ?
                new ObjectParameter("style", style) :
                new ObjectParameter("style", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getColors_prod_Result>("getColors_prod", styleParameter);
        }
    
        public virtual ObjectResult<GetEmployeebyId_Result> GetEmployeebyId(string busId, string empId)
        {
            var busIdParameter = busId != null ?
                new ObjectParameter("busId", busId) :
                new ObjectParameter("busId", typeof(string));
    
            var empIdParameter = empId != null ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetEmployeebyId_Result>("GetEmployeebyId", busIdParameter, empIdParameter);
        }
    
        public virtual int GetEmployeeByRole(string pCompanyID, string pCustID, string pUserID, string pRole)
        {
            var pCompanyIDParameter = pCompanyID != null ?
                new ObjectParameter("pCompanyID", pCompanyID) :
                new ObjectParameter("pCompanyID", typeof(string));
    
            var pCustIDParameter = pCustID != null ?
                new ObjectParameter("pCustID", pCustID) :
                new ObjectParameter("pCustID", typeof(string));
    
            var pUserIDParameter = pUserID != null ?
                new ObjectParameter("pUserID", pUserID) :
                new ObjectParameter("pUserID", typeof(string));
    
            var pRoleParameter = pRole != null ?
                new ObjectParameter("pRole", pRole) :
                new ObjectParameter("pRole", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetEmployeeByRole", pCompanyIDParameter, pCustIDParameter, pUserIDParameter, pRoleParameter);
        }
    
        public virtual int GetEmployeeByRoles1(string pCompanyID, string pCustID, string pUserID, string pRole)
        {
            var pCompanyIDParameter = pCompanyID != null ?
                new ObjectParameter("pCompanyID", pCompanyID) :
                new ObjectParameter("pCompanyID", typeof(string));
    
            var pCustIDParameter = pCustID != null ?
                new ObjectParameter("pCustID", pCustID) :
                new ObjectParameter("pCustID", typeof(string));
    
            var pUserIDParameter = pUserID != null ?
                new ObjectParameter("pUserID", pUserID) :
                new ObjectParameter("pUserID", typeof(string));
    
            var pRoleParameter = pRole != null ?
                new ObjectParameter("pRole", pRole) :
                new ObjectParameter("pRole", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetEmployeeByRoles1", pCompanyIDParameter, pCustIDParameter, pUserIDParameter, pRoleParameter);
        }
    
        public virtual int GetEmployeeByRolesLast(string pCompanyID, string pCustID, string pUserID, string pRole)
        {
            var pCompanyIDParameter = pCompanyID != null ?
                new ObjectParameter("pCompanyID", pCompanyID) :
                new ObjectParameter("pCompanyID", typeof(string));
    
            var pCustIDParameter = pCustID != null ?
                new ObjectParameter("pCustID", pCustID) :
                new ObjectParameter("pCustID", typeof(string));
    
            var pUserIDParameter = pUserID != null ?
                new ObjectParameter("pUserID", pUserID) :
                new ObjectParameter("pUserID", typeof(string));
    
            var pRoleParameter = pRole != null ?
                new ObjectParameter("pRole", pRole) :
                new ObjectParameter("pRole", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetEmployeeByRolesLast", pCompanyIDParameter, pCustIDParameter, pUserIDParameter, pRoleParameter);
        }
    }
}
