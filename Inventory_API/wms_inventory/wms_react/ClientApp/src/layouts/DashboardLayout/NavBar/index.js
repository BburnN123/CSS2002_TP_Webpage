import React, { useEffect } from 'react';
import { Link as RouterLink, useLocation } from 'react-router-dom';
import PropTypes from 'prop-types';
import {
  Avatar,
  Box,
  Button,
  Divider,
  Drawer,
  Hidden,
  List,
  Typography,
  makeStyles
} from '@material-ui/core';
import {
  Layout as LayoutIcon,
  Home as HomeIcon,
  Package as PackageIcon,
  Box as BoxIcon,
  Truck as TruckIcon,
  Calendar as CalendarIcon,
  FileText as FileTextIcon

} from 'react-feather';
import NavItem from './NavItem';



const items = [
  {
    href: '/app/dashboard', // link need to change later
    icon: LayoutIcon,
    title: 'Dashboard'
  },
  {
    href: '/app/customers',
    icon: PackageIcon,
    title: 'Cargo'
  },
  {
    href: '/app/products',
    icon: HomeIcon,
    title: 'Warehouses'
  },
  {
    href: '/app/account',
    icon: BoxIcon,
    title: 'Inventory'
  },
  {
    href: '/app/delivery',
    icon: TruckIcon,
    title: 'Delivery Tracking'
  },
  {
    href: '/app/settings',
    icon: CalendarIcon,
    title: 'Calendar'
  },
  {
    href: '/app/settings',
    icon: FileTextIcon,
    title: 'Report'
  }
];

const useStyles = makeStyles(() => ({
  mobileDrawer: {
    width: 256
  },
  desktopDrawer: {
    width: 256,
    top: 64,
    height: 'calc(100% - 64px)'
  },
  avatar: {
    cursor: 'pointer',
    width: 64,
    height: 64
  }
}));

const NavBar = ({ onMobileClose, openMobile }) => {
  const classes = useStyles();
  const location = useLocation();

  useEffect(() => {
    if (openMobile && onMobileClose) {
      onMobileClose();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [location.pathname]);

  // change navbar background color here
  const content = (
    <Box
      height="100%"
      display="flex"
      flexDirection="column"
      bgcolor="#61C1D2"
    >
      
      <Box 
      p={5}>
        <List>
          {items.map((item) => (
            <NavItem
              href={item.href}
              key={item.title}
              title={item.title}
              icon={item.icon}
            />
          ))}
        </List>
      </Box>
     
    </Box>
  );

  return (
    <>
      <Hidden lgUp>
        <Drawer
          anchor="left"
          classes={{ paper: classes.mobileDrawer }}
          onClose={onMobileClose}
          open={openMobile}
          variant="temporary"
        >
          {content}
        </Drawer>
      </Hidden>
      <Hidden mdDown>
        <Drawer
          anchor="left"
          classes={{ paper: classes.desktopDrawer }}
          open
          variant="persistent"
        >
          {content}
        </Drawer>
      </Hidden>
    </>
  );
};

NavBar.propTypes = {
  onMobileClose: PropTypes.func,
  openMobile: PropTypes.bool
};

NavBar.defaultProps = {
  onMobileClose: () => {},
  openMobile: false
};

export default NavBar;
