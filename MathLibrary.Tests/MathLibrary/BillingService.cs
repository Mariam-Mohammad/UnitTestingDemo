namespace MathLibrary;

public class BillingService
{
    public double CalculateBill(string patientType, string paymentMethod, double amount, bool insuranceApproved)
    {
        double finalAmount = amount;

        if (patientType == "VIP")
        {
            finalAmount = amount * 0.8;
        }
        else if (patientType == "Regular")
        {
            finalAmount = amount;
        }
        else if (patientType == "Emergency")
        {
            finalAmount = amount * 1.2;
        }
        else
        {
            throw new ArgumentException("Invalid patient type");
        }

        if (paymentMethod == "Insurance")
        {
            if (insuranceApproved)
                finalAmount = finalAmount * 0.5;
            else
                throw new InvalidOperationException("Insurance not approved");
        }
        else if (paymentMethod == "Cash")
        {
            finalAmount = finalAmount;
        }
        else
        {
            throw new ArgumentException("Invalid payment method");
        }

        if (finalAmount <= 0)
            throw new ArgumentException("Amount must be positive");

        return finalAmount;
    }
}