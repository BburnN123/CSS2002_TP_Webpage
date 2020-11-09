import React from 'react';
import { Navigate } from 'react-router-dom';
import DashboardLayout from 'src/layouts/DashboardLayout';
import {Home} from 'src/components/Home';


const routes = [
  {
    path: '/',
    element: <DashboardLayout />,
    children: [
      { path: 'account', element: <Home /> },
    ]
  }
];

export default routes;
