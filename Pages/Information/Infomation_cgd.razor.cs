using System.Globalization;
using Radzen;
using Radzen.Blazor;

namespace DebtInformation.Pages.Information
{
    public partial class Infomation_cgd
    {
        RadzenDataGrid<Models.Detail> deptdetailGrid;
        List<Models.Detail> datadetail;
        private List<Models.Recppaytype> recppaytype;
        private List<Models.Tofromacc> tofromacc;
        private string deptaccount_no { get; set; }
        public string defaultDate = "01/01/0544";
        //  private string operdate { get; set; } 
        DateTime Operdate { get; set; }
        private string coop_id = "065001";
        private bool isLoading;
        async Task Prosessi()
        {
            // isLoading = true;
            // try
            // {
            //     isLoading = true;
            // }
            // catch (Exception e)
            // {

            // }
            // finally
            // {
            //     isLoading = false;
            // }
        }
        //แปลงวันที่
        public async Task<string> GetConvertedDateTH()
        {
            CultureInfo thaiCulture = new CultureInfo("th-TH");
            string operdate = Operdate.ToString("dd/MM/yyyy");
            if (operdate != defaultDate)
            {
                if (DateTime.TryParseExact(operdate, "dd/MM/yyyy", thaiCulture, DateTimeStyles.None, out DateTime thaiDate))
                {
                    int gregorianYear = thaiDate.Year + 0;
                    // แปลงวันที่เป็น วันที่เดือน-วัน-ปี ค.ศ.
                    string dateOperate = $"{thaiDate.Month:00}-{thaiDate.Day:00}-{gregorianYear}";
                    return dateOperate;
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }
        }
        private async Task Getdetails()
        {
            try
            {
                isLoading = true;
                var response = await
                    httpClient.GetAsync($"{Apiurl.ApibaseUrl}DepOfInitDataOffline?coop_Control={coop_id}&deptaccount_No={deptaccount_no}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ApiResponse>(json);
                if (apiResponse.status)
                {
                    datadetail = new List<Models.Detail> { apiResponse.data };
                    Console.WriteLine($"API request failed: {datadetail}");
                }
                else
                {
                    // Handle error case
                    Console.WriteLine($"API request failed: {apiResponse.message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }
        private async Task lncnvtocontmaster()
        {
            try
            {
                isLoading = true;
                var response = await httpClient.GetAsync($"{Apiurl.Apibase}lncnvtocontmaster_CGD");
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                ProcessResponse(data);
                if (data == "OK")
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                }
                Console.WriteLine($"API request successful: {data}");
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                Console.WriteLine(ex.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }
        private async Task lncontcollnewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}lncontcollnewtoold_CGD?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task Shpmadjnchg()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}shpmadjnchg?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                    Console.WriteLine($"API request failed: {ex.Message}");
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task Slmbnewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}slmbnewtoold_CGD?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                    Console.WriteLine($"API request failed: {ex.Message}");
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task lncontstmtnewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}lncontstmtnewtoold_CGD?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                    Console.WriteLine($"API request failed: {ex.Message}");
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task shrchangenewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}shrchangenewtoold?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"API request failed: {ex.Message}");
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task Sharestmtnewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}sharestmtnewtoold_CGD?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                    Console.WriteLine($"API request failed: {ex.Message}");
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task lnreqcontadjnewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}lnreqcontadjnewtoold_GDOC?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                    Console.WriteLine($"API request failed: {ex.Message}");
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private async Task slslippayinnewtoold()
        {
            string dateOperate = await GetConvertedDateTH();
            if (dateOperate == "false")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกวันที่", Duration = 1500 });
            }
            else
            {
                isLoading = true;
                try
                {
                    var response = await httpClient.GetAsync($"{Apiurl.Apibase}slslippayinnewtoold?dateTime={dateOperate}");
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();
                    ProcessResponse(data);
                    if (data == "OK")
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "ซิงค์เรียบร้อย", Duration = 1500 });
                    }
                    Console.WriteLine($"API request successful: {data}");
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 1500 });

                    Console.WriteLine($"API request failed: {ex.Message}");
                }
                finally
                {
                    isLoading = false;
                }
            }
        }
        private Models.Informations Item = new Models.Informations();
        private void ProcessResponse(string data)
        {
            try
            {
                var item = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Informations>(data);

                if (item != null)
                {
                    Item.status = item.status;
                }
                else
                {
                    Console.WriteLine($"Failed to deserialize data to JSON object: {data}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
        }
    }
}
