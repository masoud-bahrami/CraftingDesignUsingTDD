using GoldInvestment.ApplicationService.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoldInvestment.Infrastructure.UnitTests
{
    public class DollarChnageRateTests
    {
        [Fact]
        public void Instantitation_IfChangeRateIsGreatherThanZero_InstaintaitedSuccessfully()
        {
            //Intention revealing  
            decimal dollarToRialChangeRate = 240000;
            DollarToRialChangeRate sut = CreateDollarToRialChangeRate(rate: dollarToRialChangeRate);

            var result = sut.LastChnageRate();

            Assert.Equal(dollarToRialChangeRate, result);
        }

        [Fact]
        public void Instantitation_IfChangeRateIsLowerThanZero_ExceptionThrown()
        {
            //Intention revealing  
            decimal dollarToRialChangeRate = 0;
            Assert.Throws<ZeroChnageRateDomainException>(() => CreateDollarToRialChangeRate(rate: dollarToRialChangeRate));
        }


        [Fact]
        public void ChangeRate_UpdateChnageRate_ReturnLatesChahgeRate()
        {
            decimal dollarToRialChangeRate = 240000;
            var sut = CreateDollarToRialChangeRate(dollarToRialChangeRate);

            decimal lastChnageRate = 241000;
            sut.UpdateChnageRate(lastChnageRate);

            var result = sut.LastChnageRate();
            Assert.Equal(lastChnageRate, result);
        }


        [Fact]
        public void ListOfChnageRate_UpdateChnageRate_ReturnOrderedListOfChangeRate()
        {
            decimal dollarToRialChangeRate = 240000;
            var sut = CreateDollarToRialChangeRate(dollarToRialChangeRate);

            decimal lastChnageRate = 241000;
            sut.UpdateChnageRate(lastChnageRate);

            List<ChnageRate> result = sut.GetListOfChangeRates();
            Assert.Equal(2, result.Count);
        }


        [Fact]
        public void ChangeRate_Identity()
        {
            //Value Object

            var dateTime = DateTime.Now;
            var firstChangeRate = new ChnageRate
            {
                SpecifiedAt = dateTime,
                Rate = 240000
            };
            
            var secondChangeRate = new ChnageRate
            {
                SpecifiedAt = dateTime,
                Rate = 240000
            };

            Assert.Equal(firstChangeRate, secondChangeRate);

        }

        private DollarToRialChangeRate CreateDollarToRialChangeRate(decimal rate)
        {
            return new DollarToRialChangeRate(rate);
        }
    }


}