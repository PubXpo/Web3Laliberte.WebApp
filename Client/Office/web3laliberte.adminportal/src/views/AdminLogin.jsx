import React, { useState } from 'react';
import { MdAdminPanelSettings } from "react-icons/md";
import './CSS/AdminLogin.css';
import { Helmet, HelmetProvider } from "react-helmet-async";
import { Container } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const AdminLogin = () => {
    const [password, setPassword] = useState('');
    const [error, setError] = useState(null);
    const navigate = useNavigate();
    const BASE_API_URL = process.env.REACT_APP_API_URL;
    const ADMIN_API_URL = `${BASE_API_URL}/admin/login`;

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);

        console.log('Submitting login request with password:', password);

        try {
            const response = await fetch(`${ADMIN_API_URL}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ password }),
            });

            console.log('Response status:', response.status);

            if (response.ok) {
                localStorage.setItem('isAdminAuthenticated', 'true');
                navigate('/admin');
            } else {
                const errorData = await response.json();
                console.log('Error response data:', errorData);
                setError(errorData.message || 'Invalid password');
            }
        } catch (err) {
            console.error('Login error:', err);
            setError('An error occurred. Please try again.');
        }
    };

    return (
        <>
            <HelmetProvider>
                <Helmet>
                    <title> Admin Portal | Web3 Laliberté</title>
                </Helmet>
            </HelmetProvider>
            <Container fluid className="login-container">
                <div className="login-card animate__animated animate__bounce ">
                    <h3 className="login-title">
                        <MdAdminPanelSettings /> Admin Portal
                    </h3>
                    <h4 className="login-subtitle">Only the site owners can access this realm</h4>
                    <hr />
                    <form onSubmit={handleSubmit} className="login-form">
                        <input
                            type="password"
                            id="password"
                            placeholder={"Enter admin password"}
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                        <button type="submit" className="login-button">Login</button>
                    </form>
                    {error && <div className="error-message">{error}</div>}
                </div>
            </Container>
        </>
    );
};

export default AdminLogin;