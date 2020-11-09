import React, { Component } from 'react';
import { ThemeProvider } from '@material-ui/core';
import { useRoutes } from 'react-router-dom';
import GlobalStyles from 'src/components/GlobalStyles';
import theme from 'src/theme';
import routes from 'src/routes';

import './custom.css'
import MainLayout from './layouts/MainLayout';
import DashboardLayout from './layouts/MainLayout';
import { Home } from 'src/components/Home'


const routing = useRoutes(routes);

export default class App extends Component {
  static displayName = App.name;

  render() {

    return (
      <ThemeProvider theme={theme}>
        <GlobalStyles />
   
        {routing}
      </ThemeProvider>
    );
  }
}
