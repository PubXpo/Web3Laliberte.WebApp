import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const shield = (WrappedComponent) => {
    return (props) => {
        const navigate = useNavigate();

        useEffect(() => {
            if (!localStorage.getItem('isAdminAuthenticated')) {
                navigate('/login');
            }
        }, [navigate]);

        return <WrappedComponent {...props} />;
    };
};

export default shield;