import { createMuiTheme, colors } from '@material-ui/core';
import shadows from './shadows';
import typography from './typography';
// https://material-ui.com/customization/theming/
const theme = createMuiTheme({
  palette: {
    background: {
      dark: '#F5FAFD', //F4F6F8 previous
      default: colors.common.white,
      paper: colors.common.white
    },
    primary: {
      main: '#FFFFFF'
      //main: colors.indigo[500]
    },
    secondary: {
      main: colors.indigo[500]
    },
    text: {
      primary: colors.blueGrey[900],
      secondary: colors.blueGrey[600]
    }
  },
  shadows,
  typography
});

export default theme;
