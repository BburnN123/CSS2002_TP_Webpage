import React, { Component } from 'react';
import { ThemeProvider } from '@material-ui/core';
import { useRoutes } from 'react-router-dom';
import GlobalStyles from 'src/components/GlobalStyles';
import theme from 'src/theme';
import routes from 'src/routes';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render() {
    const routing = useRoutes(routes);
    return (
      <ThemeProvider theme={theme}>
        <GlobalStyles />
        {routing}
      </ThemeProvider>
    );
  }
}
