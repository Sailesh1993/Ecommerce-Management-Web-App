import { HourglassEmpty } from '@mui/icons-material'
import { Container, Typography } from '@mui/material'

const Loading = () => {
  return (
    <Container>
        <Typography>
            <HourglassEmpty/>
        </Typography>
        <Typography variant='body2' fontSize={'large'}>
            Loading ...
        </Typography>
    </Container>
  )
}

export default Loading