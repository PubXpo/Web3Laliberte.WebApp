import React, { useState } from "react";
import "./CSS/Donate.css";
import { Helmet, HelmetProvider } from "react-helmet-async";
import { Container } from "react-bootstrap";
import PaymentModal from "../assets/Routes/PaymentModal";
import { AiFillLock } from "react-icons/ai";
import gifts from "../assets/Routes/Gifts";

const Donate = () => {
    const [currentTab, setCurrentTab] = useState("amount");
    const [otherAmount, setOtherAmount] = useState("");
    const [paymentMethod, setPaymentMethod] = useState("");
    const [showModal, setShowModal] = useState(false);
    
    const BASE_API_URL = process.env.REACT_APP_API_URL;
    const TRANSACTION_API_URL = `${BASE_API_URL}/api/transaction`;

    const handlePaymentMethodChange = (e) => {
        setPaymentMethod(e.target.value);
    };

    const [cart, setCart] = useState({
        amount: 5,
        totalExcludingTax: 4,
        donationTier: 'Band 1',
        items: [
            { name: 'Band 1', quantity: 1, pricePerUnit: 4 },
            ...gifts['Band 1'],
        ],
        billingDetails: {
            title: "Mr",
            firstName: "John",
            surname: "Doe",
            email: "john@example.com",
            postcode: "AB1 2CD",
            addressLine1: "123 Main Street",
            addressLine2: "Flat 5",
            city: "London",
            emailUpdates: "yes",
        },
    });

    const handleCustomAmount = (e) => {
        const newAmount = parseFloat(e.target.value) || 0; // Default to 0 if invalid
        setOtherAmount(e.target.value);
        setCart((prevCart) => {
            const donationTier = newAmount <= 20 ? 'Band 1' : newAmount <= 50 ? 'Band 2' : 'Band 3';
            const totalExcludingTax = newAmount - (newAmount * 0.20);
            return {
                ...prevCart,
                amount: newAmount,
                totalExcludingTax: totalExcludingTax,
                donationTier: donationTier,
                items: [
                    { name: donationTier, quantity: 1, pricePerUnit: totalExcludingTax },
                    ...gifts[donationTier],
                ],
            };
        });
    };

    const handleAmountSelection = (newAmount) => {
        setCart((prevCart) => {
            const donationTier = newAmount <= 20 ? 'Band 1' : newAmount <= 50 ? 'Band 2' : 'Band 3';
            const totalExcludingTax = newAmount - (newAmount * 0.20);
            return {
                ...prevCart,
                amount: newAmount,
                totalExcludingTax: totalExcludingTax,
                donationTier: donationTier,
                items: [
                    { name: donationTier, quantity: 1, pricePerUnit: totalExcludingTax },
                    ...gifts[donationTier],
                ],
            };
        });
        setOtherAmount("");
    };

    const handleBillingDetails = (e) => {
        const { name, value } = e.target;
        setCart((prevCart) => ({
            ...prevCart,
            billingDetails: {
                ...prevCart.billingDetails,
                [name]: value,
            },
        }));
    };

    const handleNext = () => {
        if (currentTab === "amount") {
            setCurrentTab("billing");
        } else if (currentTab === "billing") {
            setCurrentTab("checkout");
        }
    };
    
    const handleSubmit = async () => {
        try {
            const bandId = parseInt(cart.donationTier.split(" ")[1]);
            const response = await fetch(`${TRANSACTION_API_URL}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    amount: cart.amount,
                    bandId:bandId,
                    paymentMethod: paymentMethod,
                    status: "pending",
                    title: cart.billingDetails.title,
                    firstName: cart.billingDetails.firstName,
                    surname: cart.billingDetails.surname,
                    email: cart.billingDetails.email,
                    postcode: cart.billingDetails.postcode,
                    addressLine1: cart.billingDetails.addressLine1,
                    addressLine2: cart.billingDetails.addressLine2,
                    city: cart.billingDetails.city,
                    emailUpdates: cart.billingDetails.emailUpdates,
                }),
            });
            
            const responseText = await response.text(); 
            console.log("Response Text:", responseText);
    
            if (response.ok) {
                setShowModal(true);
            } else {
                console.error("Failed to submit donation:", responseText);
            }
        } catch (error) {
            console.error("Error:", error);
        }
    };

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title>Donate | Web3 Laliberté</title>
                </Helmet>
            </HelmetProvider>
            <Container fluid className="donate-wrapper">
                <div className="donate-left animate__animated animate__pulse">
                    <h3>Make a Donation</h3>
                    <h4>───&nbsp;&nbsp;Page <strong>03</strong></h4>
                </div>
                <div className="donate-right">
                    <div className="tab-navigation">
                        <button onClick={() => setCurrentTab("amount")} className={currentTab === "amount" ? "active-tab" : ""}>Amount</button>
                        <button onClick={() => setCurrentTab("billing")} className={currentTab === "billing" ? "active-tab" : ""}>Billing Details</button>
                        <button disabled={true} onClick={() => setCurrentTab("checkout")} className={currentTab === "checkout" ? "active-tab" : ""}>Checkout</button>
                    </div>
                    <div className="store-wrapper">
                        <h5><AiFillLock /> Secure form </h5>
                        {currentTab === "amount" && (
                            <div className="form-step">
                                <div className="amount-buttons">
                                    {[5, 10, 20].map((amount) => (
                                        <button
                                            key={amount}
                                            className={`amount-button ${cart.amount === amount ? "selected" : ""}`}
                                            onClick={() => handleAmountSelection(amount)}
                                        >
                                            £{amount}
                                        </button>
                                    ))}
                                    <input
                                        type="text"
                                        className="amount-input"
                                        placeholder="Other"
                                        value={cart.amount}
                                        onChange={handleCustomAmount}
                                    />
                                </div>
                                <button type="button" onClick={handleNext} className="next-button">Next</button>

                                <div className="donation-thank-you">
                                    <h3>Thank You for Your Generosity!</h3>
                                    <p>Every contribution goes a long way in supporting meaningful projects. As a token of our gratitude, each donation tier comes with a special gift:</p>

                                    <ul className="donation-tiers">
                                        <li>
                                            <strong>Band 1: £1 - £20</strong>
                                            <p>Receive a beautiful pin and our exclusive Welcome Magazine, packed with stories and insights from our projects.</p>
                                        </li>
                                        <li>
                                            <strong>Band 2: £21 - £50</strong>
                                            <p>In addition to Band 1 gifts, enjoy a limited-edition tote bag to showcase your support wherever you go!</p>
                                        </li>
                                        <li>
                                            <strong>Band 3: £100+</strong>
                                            <p>All the rewards of Band 2, plus an invitation to a behind-the-scenes virtual tour of one of our key project sites and a thank-you certificate for your impactful contribution.</p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        )}
                        {currentTab === "billing" && (
                            <div className="form-step">
                                <div className="billing-details">
                                    <h2 hidden>Billing Details</h2>
                                    <label htmlFor="title">Title:</label>
                                    <select id="title" name="title" onChange={handleBillingDetails} value={cart.billingDetails.title} required>
                                        <option value="">Select Title</option>
                                        <option value="Mr">Mr</option>
                                        <option value="Mrs">Mrs</option>
                                        <option value="Ms">Ms</option>
                                        <option value="Dr">Dr</option>
                                        <option value="Prof">Prof</option>
                                        <option value="Other">Other</option>
                                    </select>

                                    <label htmlFor="firstName">First Name:</label>
                                    <input type="text" id="firstName" name="firstName" onChange={handleBillingDetails} value={cart.billingDetails.firstName} required />

                                    <label htmlFor="surname">Surname:</label>
                                    <input type="text" id="surname" name="surname" onChange={handleBillingDetails} value={cart.billingDetails.surname} required />

                                    <label htmlFor="email">Email Address:</label>
                                    <input type="email" id="email" name="email" onChange={handleBillingDetails} value={cart.billingDetails.email} required />

                                    <label htmlFor="postcode">Postcode:</label>
                                    <input type="text" id="postcode" name="postcode" onChange={handleBillingDetails} value={cart.billingDetails.postcode} required />

                                    <label htmlFor="addressLine1">Address Line 1:</label>
                                    <input type="text" id="addressLine1" name="addressLine1" onChange={handleBillingDetails} value={cart.billingDetails.addressLine1} required />

                                    <label htmlFor="addressLine2">Address Line 2:</label>
                                    <input type="text" id="addressLine2" name="addressLine2" onChange={handleBillingDetails} value={cart.billingDetails.addressLine2} />

                                    <label htmlFor="city">City/Town:</label>
                                    <input type="text" id="city" name="city" onChange={handleBillingDetails} value={cart.billingDetails.city} required />

                                    <p>I would like to receive email updates about how I can take further action on Web3 Laliberté campaigns and how I can support your work:</p>
                                    <div className="checkbox-group">
                                        <input
                                            type="checkbox"
                                            id="emailUpdatesYes"
                                            name="emailUpdates"
                                            value="yes"
                                            checked={cart.billingDetails.emailUpdates === "yes"}
                                            onChange={handleBillingDetails}
                                        />
                                        <label htmlFor="emailUpdatesYes">Yes</label>
                                    </div>
                                    <div className="checkbox-group">
                                        <input
                                            type="checkbox"
                                            id="emailUpdatesNo"
                                            name="emailUpdates"
                                            value="no"
                                            checked={cart.billingDetails.emailUpdates === "no"}
                                            onChange={handleBillingDetails}
                                        />
                                        <label htmlFor="emailUpdatesNo">No</label>
                                    </div>

                                    <button type="button" onClick={handleNext} className="next-button">Next</button>
                                </div>
                            </div>
                        )}
                        {currentTab === "checkout" && (
                            <div className="form-step checkout">
                                <h2>Checkout</h2>
                                {/* Billing Details */}
                                <div className="billing-details">
                                    <p>{cart.billingDetails.title} {cart.billingDetails.firstName} {cart.billingDetails.surname}</p>
                                    <p>{cart.billingDetails.email}</p>
                                    <p>{cart.billingDetails.addressLine1},</p>
                                    <p>{cart.billingDetails.addressLine2}</p>
                                    <p>{cart.billingDetails.city}</p>
                                    <p>{cart.billingDetails.postcode}</p>
                                </div>
                                {/* Cart Items */}
                                <div className="cart-items">
                                    <h3>Your Cart</h3>
                                    <table>
                                        <thead>
                                            <tr>
                                                <th>Item</th>
                                                <th>Quantity</th>
                                                <th>Price per Unit</th>
                                                <th>Total Price</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {cart.items.map((item, index) => (
                                                <tr key={index}>
                                                    <td className="item-name">{item.name}</td>
                                                    <td>{item.quantity}</td>
                                                    <td>£{item.pricePerUnit.toFixed(2)}</td>
                                                    <td>£{(item.quantity * item.pricePerUnit).toFixed(2)}</td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                    <div className="checkout-sum">
                                        <p className="total-price">
                                            Total (excl. tax): £{cart.totalExcludingTax.toFixed(2)}
                                        </p>
                                        <p className="tax-price">
                                            Tax (20%): £{(cart.amount * 0.2).toFixed(2)}
                                        </p>
                                        <p className="grand-total">
                                            Total (incl. tax): £{(cart.amount).toFixed(2)}
                                        </p>
                                    </div>
                                </div>
                                {/* Payment Options */}
                                <div className="payment-options">
                                    <h3>Payment Options</h3>
                                    <div className="payment-method">
                                        <input type="radio" id="creditCard" name="paymentMethod" value="creditCard" onChange={handlePaymentMethodChange} required />
                                        <label htmlFor="creditCard">Credit Card</label>
                                    </div>
                                    <div className="payment-method">
                                        <input type="radio" id="paypal" name="paymentMethod" value="paypal" onChange={handlePaymentMethodChange} required />
                                        <label htmlFor="paypal">PayPal</label>
                                    </div>
                                </div>
                                {/* Payment Details */}
                                {paymentMethod === "creditCard" && (
                                    <div className="payment-details">
                                        <label htmlFor="cardholderName">Cardholder Name:</label>
                                        <input
                                            type="text"
                                            id="cardholderName"
                                            name="cardholderName"
                                            placeholder="Enter cardholder name"
                                            value={cart.billingDetails.title + " " + cart.billingDetails.firstName + " " + cart.billingDetails.surname}
                                            onChange={handleBillingDetails}
                                            required
                                        />
                                        <label htmlFor="cardNumber">Card Number:</label>
                                        <input
                                            type="text"
                                            id="cardNumber"
                                            name="cardNumber"
                                            placeholder="Enter card number"
                                            value={1234567890123456}
                                            onChange={handleBillingDetails}
                                            required
                                        />
                                        <label htmlFor="expiryDate">Expiration Date:</label>
                                        <input
                                            type="text"
                                            id="expiryDate"
                                            name="expiryDate"
                                            placeholder="MM/YY"
                                            value="12/28"
                                            onChange={handleBillingDetails}
                                            required
                                        />
                                        <label htmlFor="cvv">CVV:</label>
                                        <input
                                            type="text"
                                            id="cvv"
                                            name="cvv"
                                            placeholder="Enter CVV"
                                            value={123}
                                            onChange={handleBillingDetails}
                                            required
                                        />
                                    </div>
                                )}
                                <button type="button" onClick={handleSubmit} className="submit-button">PAY</button>
                            </div>
                        )}
                    </div>
                </div>
            </Container>
            <PaymentModal show={showModal} handleClose={() => setShowModal(false)} handlePayment={handleSubmit} />
        </>
    );
};

export default Donate;