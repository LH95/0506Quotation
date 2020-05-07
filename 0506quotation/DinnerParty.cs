using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506quotation
{
    class DinnerParty
    {
        /// <summary>
        /// party for dinner
        /// </summary>
        public const int CostOfFoodPerPerson = 25;

        // 使用原來的public 會產生bug 讓裝飾價格一直是舊的數據
        private int numberOfPeople;
        //property特性 呼叫CalculateCostOfDecorations 的set存取器
        //確保裝飾價格在人數改變時會被重新計算
        public int NumberOfPeople
        {
            //accessor
            get { return numberOfPeople; }
            set
            {
                numberOfPeople = value;
                CalculateCostOfDecorations(fancyDecorations);
            }
        }
        //創立fancyDecorations 給上面
        private bool fancyDecorations;

        public decimal CostOfBeveragesPerPerson;
        public decimal CostOfDecorations = 0;


        //constructor 初始化私有欄位
        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            this.fancyDecorations = fancyDecorations;
            SetHealthyOption(healthyOption);
            CalculateCostOfDecorations(fancyDecorations);
        }

        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption)
            {
                CostOfBeveragesPerPerson = 5.00M;
            }
            else
            {
                CostOfBeveragesPerPerson = 20.00M;
            }
        }


        public void CalculateCostOfDecorations(bool fancy)
        {
            fancyDecorations = fancy;
            if (fancy)
            {
                CostOfDecorations = (NumberOfPeople * 15.00M) + 50.00M;
            }
            else
            {
                CostOfDecorations = (NumberOfPeople * 7.50M) + 30.00M;
            }
        }

        //總費用
        public decimal Colculatecoast(bool healthyOption)
        {
            decimal totalCost = CostOfDecorations + ((CostOfBeveragesPerPerson + CostOfFoodPerPerson) * NumberOfPeople);

            if (healthyOption)
            {
                return totalCost * 0.95M;
            }
            else
            {
                return totalCost;
            }
        }
    }
}
