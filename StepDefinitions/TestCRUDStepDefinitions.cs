using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace Lab3.StepDefinitions
{
    [Binding]
    public class TestCRUDStepDefinitions
    {
        private RestClient client =  new RestClient("http://restful-booker.herokuapp.com");
        private RestRequest request;
        private RestResponse response;
        private int bookingIdForGet = 1662;
        private int bookingIdForUpdate = 3428;
        private int bookingIdForDelete = 742;


        [Given(@"I have a valid booking payload")]
        public void GivenIHaveAValidBookingPayload()
        {
            request = new RestRequest("/booking", Method.POST);
            request.AddJsonBody(new
            {
                firstname = "John",
                lastname = "Doe",
                totalprice = 150,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2024-11-01",
                    checkout = "2024-11-10"
                },
                additionalneeds = "Breakfast"
            });

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
        }

        [When(@"I send a POST request to ""([^""]*)""")]
        public void WhenISendAPOSTRequestTo(string p0)
        {
            response = (RestResponse)client.Execute(request);
        }

        [Then(@"I receive a (.*) status code")]
        public void ThenIReceiveAStatusCode(int status)
        {
            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(status, (int)response.StatusCode, "Response status code is not 200");

        }

        [Given(@"I have the booking ID of an existing booking")]
        public void GivenIHaveTheBookingIDOfAnExistingBooking()
        {
            client = new RestClient("http://restful-booker.herokuapp.com");
            Assert.IsNotNull(bookingIdForGet, "Booking ID should not be null");

            request = new RestRequest($"/booking/{bookingIdForGet}", Method.GET);
            request.AddHeader("Accept", "application/json");
        }

        [When(@"I send a GET request to ""([^""]*)""")]
        public void WhenISendAGETRequestTo(string p0)
        {
            response = (RestResponse)client.Execute(request);
        }

        [Then(@"I receive a (.*) status code for get by ID")]
        public void ThenIReceiveAStatusCodeForGetById(int status)
        {
            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(status, (int)response.StatusCode, "Response status code is not 200");
        }

        [Given(@"I have the booking ID of an existing booking for update")]
        public void GivenIHaveTheBookingIDOfAnExistingBookingForUpdate()
        {
            client = new RestClient("http://restful-booker.herokuapp.com");
            Assert.IsNotNull(bookingIdForUpdate, "Booking ID should not be null");

            request = new RestRequest($"/booking/{bookingIdForUpdate}", Method.PUT);
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
            request.AddHeader("Accept", "application/json");
        }

        [Given(@"I have an updated booking payload")]
        public void GivenIHaveAnUpdatedBookingPayload()
        {
            request.AddJsonBody(new
            {
                firstname = "Jane",
                lastname = "Smith",
                totalprice = 200,
                depositpaid = false,
                bookingdates = new
                {
                    checkin = "2024-12-01",
                    checkout = "2024-12-15"
                },
                additionalneeds = "Lunch"
            });
        }

        [When(@"I send a PUT request to ""([^""]*)""")]
        public void WhenISendAPUTRequestTo(string p0)
        {
            response = (RestResponse)client.Execute(request);
        }

        [Then(@"I receive a (.*) status code for update")]
        public void ThenIReceiveAStatusCodeForUpdate(int status)
        {
            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(status, (int)response.StatusCode, "Response status code is not 200");
        }

        [Given(@"I have the booking ID of an existing booking for delete")]
        public void GivenIHaveTheBookingIDOfAnExistingBookingForDelete()
        {
            client = new RestClient("http://restful-booker.herokuapp.com");
            Assert.IsNotNull(bookingIdForDelete, "Booking ID should not be null");

            request = new RestRequest($"/booking/{bookingIdForDelete}", Method.DELETE);
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
        }

        [When(@"I send a DELETE request to ""([^""]*)""")]
        public void WhenISendADELETERequestTo(string p0)
        {
            response = (RestResponse)client.Execute(request);
        }

        [Then(@"I receive a (.*) status code for delete")]
        public void ThenIReceiveAStatusCodeForDelete(int status)
        {
            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(status, (int)response.StatusCode, "Response status code is not 200");
        }

    }
}
