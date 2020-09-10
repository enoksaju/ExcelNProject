import React from 'react';
import { Tooltip, ListItem, ListItemIcon, ListItemText } from '@material-ui/core';
import { Link as RouterLink } from 'react-router-dom';

function ListItemLink(props) {
    const { icon, primary, to, onClick } = props;

    const RenderLink = React.useMemo(
        () =>
            React.forwardRef((itemProps, ref) => (
                <RouterLink to={to} ref={ref} {...itemProps} />
            )),
        [to]
    );

    return (
        <Tooltip title={primary} placement="right" arrow>
            <ListItem button component={RenderLink} onClick={onClick}>
                {icon && <ListItemIcon>{icon}</ListItemIcon>}
                <ListItemText primary={primary} />
            </ListItem>
        </Tooltip>
    );
}

export { ListItemLink }
