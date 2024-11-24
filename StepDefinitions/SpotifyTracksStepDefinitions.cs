using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace Lab3.StepDefinitions
{
    [Binding]
    public class SpotifyTracksStepDefinitions
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        //https://accounts.spotify.com/authorize?client_id=ae59bc54b3b245a795469ed383ac0cf6&response_type=token&redirect_uri=https://oauth.pstmn.io/v1/callback&scope=user-read-private
        //https://oauth.pstmn.io/v1/callback?token=
        private string apiToken = "BQDjgYUTARDq-WfjGDDwKYlPpDKIpz3SG06T2P1ZJjmbYlUEk4TxssC2bQfSZzncyWaEE65WO2VioIhAJjmf4NKY-PZqLkBcp51z7AxOlzbocPHSUG1p94vC1awCyA_Q-6KYkPnrnyzOxv0egvcFMovjrPaL0xdEorlubakYPOWaxeQ0VvmBoVuIMHxME_QotYSrHuaMxTV-BPOJU6dddi5Z";
        //https://open.spotify.com/track/4Gd9PUEuOTOJtbgd4YxLXM?si=f28c4f7ea4434e44
        private string trackValidId = "4Gd9PUEuOTOJtbgd4YxLXM";
        private string trackInvalidId = "123";

        [Given(@"I have a valid Spotify API token and trackId of an existing track")]
        public void GivenIHaveAValidSpotifyAPITokenAndTrackIdOfAnExistingTrack()
        {
            client = new RestClient("https://api.spotify.com/v1");

            request = new RestRequest($"/tracks/{trackValidId}", Method.GET);
            request.AddHeader("Accept", "application/json");

            request.AddHeader("Authorization", $"Bearer {apiToken}");
            request.AddQueryParameter("market", "UA");
        }


        [When(@"I send a GET request to the ""([^""]*)"" endpoint")]
        public void WhenISendAGETRequestToTheEndpoint(string p0)
        {
            response = (RestResponse)client.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int status)
        {
            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(status, (int)response.StatusCode, "Response status code is not 200");
        }

        [Given(@"I have a valid Spotify API token and and trackId")]
        public void GivenIHaveAValidSpotifyAPITokenAndAndTrackId()
        {
            client = new RestClient("https://api.spotify.com/v1");

            request = new RestRequest($"/tracks/{trackInvalidId}", Method.GET);
            request.AddHeader("Accept", "application/json");

            request.AddHeader("Authorization", $"Bearer {apiToken}");
            request.AddQueryParameter("market", "UA");
        }

        [When(@"I send a GET request to the ""([^""]*)"" endpoint with invalid id")]
        public void WhenISendAGETRequestToTheEndpointWithInvalidId(string p0)
        {
            response = (RestResponse)client.Execute(request);
        }

        [Then(@"I receive a (.*) status code for with test")]
        public void ThenIReceiveAStatusCodeForWithTest(int status)
        {
            Assert.IsNotNull(response, "Response is null");
            Assert.AreEqual(status, (int)response.StatusCode, "Response status code is not 400");
        }


    }
}
