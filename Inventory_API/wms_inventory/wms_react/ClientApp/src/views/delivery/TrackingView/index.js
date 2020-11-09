import React from 'react';
import {
  Container,
  Grid,
  makeStyles
} from '@material-ui/core';
import Page from 'src/components/Page';

//import Profile from './Profile';
//import ProfileDetails from './ProfileDetails';

import TrackingTab from './TrackingTab';
import TrackCargo from './TrackCargo';

const useStyles = makeStyles((theme) => ({
  root: {
    backgroundColor: theme.palette.background.dark,
    minHeight: '100%',
    paddingBottom: theme.spacing(3),
    paddingTop: theme.spacing(3)
  }
}));

const Delivery = () => {
  const classes = useStyles();

  return (
    <Page
      className={classes.root}
      title="Delivery"
    >
      <Container maxWidth="lg">
        <Grid
          container
          spacing={3}
        >
          <Grid
            item
            lg={12}
            md={12}
            xs={12}
          >
            <h2>Delivery Tracking</h2>
            <br/>
            <TrackingTab />
          </Grid>

          <Grid
            item
            lg={12}
            md={12}
            xs={12}
          >
            <h3>Track Cargo</h3>
            <br/>
            <TrackCargo />
          </Grid>
        </Grid>
      </Container>
    </Page>
  );
};

export default Delivery;
