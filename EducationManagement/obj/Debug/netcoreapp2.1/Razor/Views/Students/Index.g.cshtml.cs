#pragma checksum "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a26b400bf87b803c481d0c09a1be9ad74619f1c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Students_Index), @"mvc.1.0.view", @"/Views/Students/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Students/Index.cshtml", typeof(AspNetCore.Views_Students_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\_ViewImports.cshtml"
using EducationManagement;

#line default
#line hidden
#line 2 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\_ViewImports.cshtml"
using EducationManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a26b400bf87b803c481d0c09a1be9ad74619f1c6", @"/Views/Students/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5a61dd19d47cb9ad4a38b8066ac0b299a3fe777", @"/Views/_ViewImports.cshtml")]
    public class Views_Students_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EducationManagement.Entities.Students>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline form-group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Export", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(102, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(131, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a9accce2a264c06908b566e578e4c86", async() => {
                BeginContext(178, 15, true);
                WriteLiteral("Create Students");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(197, 557, true);
            WriteLiteral(@"
</p>
<button id=""btnImport"" type=""button"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#myModal"">
    Import
</button>
<div id=""myModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog modal-lg"">

        <!-- Modal content-->
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">File</h4>
            </div>
            <div class=""modal-body"">
                ");
            EndContext();
            BeginContext(754, 669, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1926d75009574af896ce3127ef092a78", async() => {
                BeginContext(804, 612, true);
                WriteLiteral(@"
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <input type=""file"" id=""fUpload"" name=""files"" class=""form-control"" />
                        </div>
                        <div class=""col-md-1"">
                            <input type=""button"" id=""btnUpload"" value=""Upload"" class=""btn btn-info"" />
                        </div>
                    </div>
                    <br />
                    <table id=""dvData"" class=""table table-striped table-bordered table-responsive display "" style=""width:100%""></table>
                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1423, 60, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n");
            EndContext();
            BeginContext(1483, 322, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85f241b5c21d4f538dc3f7a5b9b4d19f", async() => {
                BeginContext(1520, 278, true);
                WriteLiteral(@"
    <div style=""float:right"">
        <input type=""text"" id=""search"" class=""form-control"" style=""width:250px"" placeholder=""Search here…"" />
        <button id=""btnSubmit"" type=""button"" class=""btn btn-info fa fa-search"" style=""height:34px;float:right""></button>
    </div>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1805, 212, true);
            WriteLiteral("\r\n<table name=\"\" id=\"indexTable\" class=\"table table-striped table-bordered table-responsive display \" style=\"width:100%\"></table>\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\" style=\"padding-top:10px;\">\r\n        ");
            EndContext();
            BeginContext(2017, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f568f3995639404b8b6336b81c08d574", async() => {
                BeginContext(2072, 6, true);
                WriteLiteral("Export");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2087, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2126, 203, true);
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            var table = $(\"#indexTable\").DataTable({\r\n                \"serverSide\": true,\r\n                \"ajax\": {\r\n                    \"url\": \"");
                EndContext();
                BeginContext(2330, 41, false);
#line 60 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml"
                       Write(Url.Action("GetListStudents", "Students"));

#line default
#line hidden
                EndContext();
                BeginContext(2371, 1698, true);
                WriteLiteral(@""",
                    ""type"": ""POST"",
                    ""data"": function(d) {
                        d.name = $(""#search"").val()
                    }
                },
                ""columns"": [
                    {
                        ""title"": ""STT"",
                        ""data"": null,
                        ""defaultContent"": """"
                    },
                    {
                        ""title"": ""Name"",
                        ""data"": ""name""
                    },
                    {
                        ""title"": ""Code student"",
                        ""data"": ""studentId""
                    },
                    {
                        ""title"": ""Grades"",
                        ""data"": ""nameGrade"",
                    },
                    {
                        ""title"": ""Classes"",
                        ""data"": ""nameClass"",
                    },
                    {
                        ""title"": ""Day of birth"",
                      ");
                WriteLiteral(@"  ""data"": ""dob""
                    },
                    {
                        ""title"": ""Gender"",
                        ""data"": ""gender""
                    },
                    {
                        ""title"": ""Create Date"",
                        ""data"": ""createDate""
                    },
                    {
                        ""title"": ""Update Date"",
                        ""data"": ""updateDate""
                    },
                    {
                        ""title"": ""Action"",
                        ""orderable"": false,
                        ""render"": function (a, b, data) {
                            return ""<a href='");
                EndContext();
                BeginContext(4071, 29, false);
#line 108 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml"
                                         Write(Url.Action("Edit","Students"));

#line default
#line hidden
                EndContext();
                BeginContext(4101, 79, true);
                WriteLiteral("?id=\" + data.id + \"\'>Edit</a> | \" +\r\n                                \"<a href=\'");
                EndContext();
                BeginContext(4182, 31, false);
#line 109 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml"
                                      Write(Url.Action("Delete","Students"));

#line default
#line hidden
                EndContext();
                BeginContext(4214, 1177, true);
                WriteLiteral(@"?id="" + data.id + ""'>Delete</a> "";
                        }
                    }
                ],
                ""lengthMenu"": [[2, 25, 50, -1], [2, 25, 50, ""All""]],
                ""searching"": false
            });
            $(""#btnSubmit"").click(function () {
                table.clear().draw();
            });
        });
        jQuery(""#btnUpload"").click(function () {
            var fileExtension = ['xls', 'xlsx'];
            var filename = $(""#fUpload"").val();
            if (filename.length == 0) {
                alert(""Please select a file."");
                return false;
            }
            else {
                var extension = filename.replace(/^.*\./, '');
                if ($.inArray(extension, fileExtension) == -1) {
                    alert(""Please select only excel files."");
                    return false;
                }
            }
            var fileUpload = $(""#fUpload"").get(0);
            var files = fileUpload.files;
            var");
                WriteLiteral(" fdata = new FormData();\r\n            fdata.append(files[0].name, files[0]);\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \'");
                EndContext();
                BeginContext(5392, 37, false);
#line 140 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml"
                 Write(Url.Action("OnPostImport","Students"));

#line default
#line hidden
                EndContext();
                BeginContext(5429, 596, true);
                WriteLiteral(@"',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader(""XSRF-TOKEN"",
                        $('input:hidden[name=""__RequestVerificationToken""]').val());
                },
                data: fdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess = true) {
                        var table = $(""#dvData"").DataTable({
                        ""serverSide"": true,
                        ""ajax"": {
                            ""url"": """);
                EndContext();
                BeginContext(6026, 37, false);
#line 153 "F:\Năm 4\EducationManagementASP\EducationManagement\EducationManagement\Views\Students\Index.cshtml"
                               Write(Url.Action("ExcelPaging", "Students"));

#line default
#line hidden
                EndContext();
                BeginContext(6063, 1974, true);
                WriteLiteral(@""",
                            ""type"": ""POST"",
                            ""data"": function (d) {
                                d.fileName = response.fileName
                            }
                        },
                        ""columns"": [
                            {
                                ""title"": ""STT"",
                                ""data"": ""stt"",
                            },
                            {
                                ""title"": ""Mã SV"",
                                ""data"": ""studentId""
                            },
                            {
                                ""title"": ""HỌ TÊN SINH VIÊN"",
                                ""data"": ""lastName""
                            },
                            {
                                ""title"": ""TÊN"",
                                ""data"": ""firstName"",
                            },
                            {
                                ""title"": ""NGÀY SINH"",
      ");
                WriteLiteral(@"                          ""data"": ""dob"",
                            },
                            {
                                ""title"": ""LỚP"",
                                ""data"": ""className""
                            },
                            {
                                ""title"": ""KHỐI"",
                                ""data"": ""gradeName""
                            },
                            {
                                ""title"": ""PHÁI"",
                                ""data"": ""gender""
                            }
                        ],
                        ""lengthMenu"": [[10, 25, 50, -1], [10, 25, 50, ""All""]],
                        ""searching"": false
                    });
                    }
                },
                error: function (e) {
                    $('#dvData').html(e.responseText);
                }
            });
        });
    </script>
    ");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EducationManagement.Entities.Students>> Html { get; private set; }
    }
}
#pragma warning restore 1591
